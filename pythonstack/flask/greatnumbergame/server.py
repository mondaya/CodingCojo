from flask import Flask, render_template, request , session,redirect # Import Flask and  more to allow us to create our app.
import random
app = Flask(__name__)    # Global variable __name__ tells Flask whether or not we are running the file
                         # directly, or importing it as a module.
@app.route('/')          # The "@" symbol designates a "decorator" which attaches the following
                         # function to the '/' route. This means that whenever we send a request to
                         # localhost:5000/ we will run the following "hello_world" function.
def index():
    
  if 'choosen_num' not in session :
    session['choosen_num'] = random.randrange(0, 101) # random number between 0-100
  return render_template('index.html')  # Return main page.

@app.route('/guessed', methods=['POST'])
def process_guessed_num():
    session['guessed_num'] = request.form['guessed_num']
    if int(session['guessed_num']) < int(session['choosen_num']) :
        session['below'] = True
        session['above'] = False
    elif int(session['guessed_num']) > int(session['choosen_num']) :
        session['below'] = False
        session['above'] = True
    else :
        session['below'] = False
        session['above'] = False
        session['won'] = True
    print session    
    return redirect('/')

@app.route('/reset', methods=['POST'])
def reset():
    session['won'] = False
    session.pop('choosen_num', None)
    return redirect('/')


app.secret_key = 'password'
app.run(debug=True)      # Run the app in debug mode.