from flask import Flask  # Import Flask to allow us to create our app
app = Flask(__name__)    # Create a new instance of the Flask class called "app"
@app.route('/')          # The "@" decorator associates this route with the function immediately following
def hello_world():
    return 'Hello World!'  

@app.route('/dojo')
def dojo():
    return "Dojo!"

@app.route('/say/<flask>')
def flask(flask):
    return f'Hi {flask}'

@app.route('/repeat/<int:num>/<string:bob>')
def repeat(num, bob):
    if bob == "hello" or bob == "bye" or bob == "dogs":
        return bob * num
    else:
        return "Sorry! No response. Try again."
if __name__=="__main__":   # Ensure this file is being run directly and not from a different module    
    app.run(debug=True)   






"""
============= TO GET IT ON FILE ==================
pipenv install flask



============= TO ACTIVATE SERVER =================

pipenv install
pipenv shell
"""