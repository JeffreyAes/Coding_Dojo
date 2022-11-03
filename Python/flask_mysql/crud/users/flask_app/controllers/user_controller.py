from flask_app import app
from flask import render_template,redirect,request,session
from flask_app.models.user_model import User


@app.route('/')
def index():
    return redirect('/users')


@app.route('/users')
def users():
    return render_template("users_all.html", users=User.get_all())


@app.route("/users/create")
def create_user():
    return render_template("create.html")


@app.route("/users/<int:id>/show")
def show_user(id):
    one_user = User.get_one({"id": id})
    return render_template("user_show_one.html", one_user=one_user)


@app.route("/insert_user", methods=["POST"])
def addUser():
    User.save(request.form)
    return redirect('/users')


@app.route("/users/<int:id>/delete")
def delete_user(id):
    data = {
        'id': id
    }
    User.delete(data)
    return redirect('/')


@app.route("/users/<int:id>/edit")
def edit_user(id):
    data = {
        'id':id
    }

    this_user = User.get_one(data)
    return render_template("edit_user.html", this_user=this_user)

@app.route("/users/<int:id>/update", methods=["POST"])
def update_user(id):
    data = {
        **request.form,
        'id':id
    }
    User.update(data)
    return redirect('/')