from flask import Flask, render_template,  redirect, request, session# Import Flask to allow us to create our app.
app = Flask(__name__)    # Global variable __name__ tells Flask whether or not we are running the file
app.secret_key = "password"  
                         # directly, or importing it as a module.
@app.route('/')          # The "@" symbol designates a "decorator" which attaches the following
                         # function to the '/' route. This means that whenever we send a request to
                         # localhost:5000/ we will run the following "hello_world" function.

def index():
  return render_template('index.html')

# this route will handle our form submission
# notice how we defined which HTTP methods are allowed by this route
  
@app.route('/users',  methods=['POST'])
def create_user():
    print "Got Post info"
    session['name'] = request.form['name']
    session['email'] = request.form['email']
    # redirect back to the '/' route
    
    return redirect('/show')  

@app.route('/show')
def show_user():
  # return render_template('user.html', name=session['name'], email=session['email'])   
  return render_template('user.html')  


app.run(debug=True)      # Run the app in debug mode.

