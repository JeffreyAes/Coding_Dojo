from flask import Flask, render_template, request, redirect

from user import User
app = Flask(__name__)


@app.route("/")
def index():

    users = User.get_all()
    print(users)
    return render_template('read_all.html', users=users)


@app.route("/create_user")
def create_user():
    return render_template("create.html")


@app.route("/insert_user", methods=["POST"])
def addUser():
    User.save(request.form)
    return redirect('/')


if __name__ == "__main__":
    app.run(debug=True)
