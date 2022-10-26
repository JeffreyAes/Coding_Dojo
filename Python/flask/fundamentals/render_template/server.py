from flask import Flask, render_template

app = Flask(__name__)    # Create a new instance of the Flask class called "app"

@app.route('/')          # The "@" decorator associates this route with the function immediately following
def index():
    return render_template("index.html")

@app.route('/success')
def success():
    return "success!"

@app.route('/hello/<string:banana>/<int:num>')
def hello(banana, num):
    return render_template("hello.html", banana = banana, num = num)
# Return the string 'Hello World!' as a response
if __name__=="__main__":   # Ensure this file is being run directly and not from a different module    
    app.run(debug=True)    # Run the app in debug mode.

"""
============= TO GET INSTALL FLASK ==================
1. pipenv install flask
2. pipenv install


============= TO ACTIVATE SERVER =================
3. pipenv shell
"""