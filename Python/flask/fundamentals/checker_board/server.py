from flask import Flask, render_template

app = Flask(__name__)    # Create a new instance of the Flask class called "app"

@app.route('/')          # The "@" decorator associates this route with the function immediately following
@app.route('/<int:num2>')
@app.route('/<int:num1>/<int:num2>')
@app.route('/<int:num1>/<int:num2>/<color1>/<color2>')
def index(num1 = 8, num2 = 8, color1 = 'black', color2 = 'red'):
    return render_template("index.html", num1 = num1, num2 = num2, color1 = color1, color2 = color2)

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