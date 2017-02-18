from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import re
from flask.ext.bcrypt import Bcrypt

app = Flask(__name__)
app.secret_key = "ThisIsSecret!"
bcrypt = Bcrypt(app)
mysql = MySQLConnector(app,'walldb')

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
PASSWORD_REGEX = re.compile('^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{4,8}$')
NAMES_REGEX = re.compile('^[a-zA-Z]+$')

@app.route('/')
def index():
  return render_template('index.html')

@app.route('/create',methods=['POST'])
def registration():
  error = []
  if isEmpty(request.form['first_name']):
      error.append("First name can not be blank")
  elif not isPattern(NAMES_REGEX, request.form['first_name']):
      error.append('Sorry, there may be invalid character in the first name field!')
  #checking the last name entry values!
  if isEmpty(request.form['last_name']):
      error.append("Last name can not be blank")
  elif not isPattern(NAMES_REGEX, request.form['last_name']):
      error.append('Sorry, there may be invalid characters in the last name field!')
  #checking if the email is valid!
  if isEmpty(request.form['email']) :
      error.append('Email can not be blank!')
  elif not isPattern(EMAIL_REGEX, request.form['email']):
      error.append('Please enter a valid email!')
  #Checking the password!
  if isEmpty(request.form['email']):
      error.append('Please enter your password')
  else:
      # read e-mail to make sure they don't exits from mysql
      query = "SELECT * FROM users WHERE email = '{}'".format(request.form['email'])
      user = mysql.query_db(query)
      if user :
          error.append("User already exits")

      if len(request.form['password']) < 8:
          error.append('password to short!')
      if not request.form['password'] == request.form['conf_pass']:
              errors.append('Passwords must match!')
      print 'email'
      if len(error) > 0:
         flashMessages(error)
         return redirect("/")

      else:
          password = bcrypt.generate_password_hash(request.form['password'])
          query = "INSERT INTO users(first_name, last_name, email, password, created_at, updated_at) VALUES (:first_name,:last_name,:email,:password,NOW(),NOW())"

          data = {
              'first_name':request.form['first_name'],
              'last_name':request.form['last_name'],
              'email':request.form['email'],
              'password':password,
          }
          user_id = mysql.query_db(query, data)
          session['user_id'] = user_id
  return redirect('/success')
 
@app.route("/login", methods=["POST"])
def login():
    errors = []
    # user is in session
    if 'user_id' in session:
        # remove session
        session.pop('user_id')        
    #reauthenticate
    # validate againt db
    #if successful #create a session            
    if verifyUserSetSession(request.form['email'], request.form['password'], errors):
       #redirect to the wall page
       return redirect("/success")
    else:
      flashMessages(errors)   
      return redirect("/")
    
@app.route("/success")
def showTheWall():
    getPostsDb()
    buildUsersLookup()
    buildCommentsLookup()    
    return render_template("wall.html")

@app.route("/postmessage", methods=["POST"])
def postMessage():
    post_message = request.form['content']
    if not isEmpty(post_message):
        insertPostDb(session['user_id'], post_message)
    return redirect("/success")
        
@app.route("/comment", methods=["POST"])
def commentMessage():
    print request.form
    comment_message = request.form['content']
    if not isEmpty(comment_message):
        insertCommentDb(session['user_id'], request.form['msg_id'], comment_message)
    return redirect("/success")

    
def flashMessages(msgs=[]):
    if len(msgs) > 0:
         for message in msgs:
          flash(message)
    
def isEmpty(val):
     return len(val) < 1
     
def isPattern(pattern, val):
     return pattern.match(val)

def verifyUserSetSession(userId, password, errMsg=[]):
    
     query = "SELECT * FROM users WHERE email = '{}'".format(userId)
     user = mysql.query_db(query)
     if not user :
        errMsg.append("UserId {} not found in the Wall!".format(userId))
        return False
     user_password = bcrypt.generate_password_hash(password)
     if not bcrypt.check_password_hash(user[0]['password'], password):
        errMsg.append('Passwords for UserId {} does not match the one in the Wall!'.format(userId))
        return False
      
     session['user_id'] = user[0]['id']
     return True

def buildUsersLookup():

    query = "SELECT id,first_name, last_name FROM users"
    users_db = mysql.query_db(query)
    users={}
    for user in users_db:
        users[user['id']]= (user['first_name'], user['last_name'])
    session['users'] = users
        
def buildCommentsLookup():

    query = "SELECT * FROM walldb.comments ORDER BY message_id, updated_at desc;"
    comments_db = mysql.query_db(query)
    comments={}
    for comment in comments_db:
        if comment['message_id'] not in comments:
            comments[comment['message_id']]= [(comment['user_id'], comment['comment'],comment['updated_at'])]
        else:
           comments[comment['message_id']].append((comment['user_id'], comment['comment'],comment['updated_at']))
    session['comments'] = comments
     
     
def insertPostDb(userId, msg):    
     query = "INSERT INTO messages(user_id, message,created_at, updated_at) VALUES (:user_id,:message,NOW(),NOW())"
     data = {
          'user_id':userId,
          'message':msg              
      }
     mysql.query_db(query, data)
     
def insertCommentDb(userId, msg_id, msg):    
     query = "INSERT INTO comments(message_id,user_id,comment,created_at,updated_at) VALUES (:message_id,:user_id,:comment,NOW(),NOW())"
     data = {
          'message_id':msg_id,
          'user_id':userId,
          'comment':msg              
      }
     mysql.query_db(query, data)
      
def getPostsDb():
    
     query = "SELECT u.first_name, u.last_name, m.message, m.id as msg_id, m.updated_at FROM messages m join users u on m.user_id = u.id ORDER BY m.updated_at desc;"
     session['posts'] = mysql.query_db(query)
          
app.run(debug=True)