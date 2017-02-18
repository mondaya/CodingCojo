from flask import Flask, render_template, request , session,redirect # Import Flask and  more to allow us to create our app.
app = Flask(__name__)    # Global variable __name__ tells Flask whether or not we are running the file
                         # directly, or importing it as a module.
@app.route('/')          # The "@" symbol designates a "decorator" which attaches the following
                         # function to the '/' route. This means that whenever we send a request to
                         # localhost:5000/ we will run the following "hello_world" function.
def index():
  if 'counter' not in session :
    session['counter'] = 1
  else:
    session['counter'] += 1
  return render_template('index.html')  # Return main page.

@app.route('/add2', methods=['POST'])
def add2():
    session['counter'] += 2
    return redirect('/apply')

@app.route('/reset', methods=['POST'])
def reset():
    session['counter'] = 1
    return redirect('/apply')

@app.route('/apply')
def apply():
    return render_template('index.html')

app.secret_key = 'password'
app.run(debug=True)      # Run the app in debug mode.