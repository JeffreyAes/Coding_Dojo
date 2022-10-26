from flask import Flask  # Import Flask to allow us to create our app
app = Flask(__name__)    # Create a new instance of the Flask class called "app"
@app.route('/')          # The "@" decorator associates this route with the function immediately following
def hello_world():
    return 'Hello World!'  

@app.route('/success')
def success():
    return "success!"

@app.route('/hello/<string:banana>/<int:num>')
def hello(banana, num):
    return f"hello {banana * num} "
# Return the string 'Hello World!' as a response
if __name__=="__main__":   # Ensure this file is being run directly and not from a different module    
    app.run(debug=True)    # Run the app in debug mode.

"""
============= TO GET IT ON FILE ==================
pipenv install flask



============= TO ACTIVATE SERVER =================

pipenv install
pipenv shell
"""