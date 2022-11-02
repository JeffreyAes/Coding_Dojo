from flask import Flask, render_template, request, redirect

from user import User
app = Flask(__name__)


@app.route('/')
def index():
    return redirect('/users')


@app.route('/users')
def users():
    return render_template("read_all.html", users=User.get_all())


@app.route("/create_user")
def create_user():
    return render_template("create.html")


@app.route("/insert_user", methods=["POST"])
def addUser():
    User.save(request.form)
    return redirect('/users')


if __name__ == "__main__":
    app.run(debug=True)
