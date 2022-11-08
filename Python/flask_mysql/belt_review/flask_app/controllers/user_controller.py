from flask_app import app
from flask import render_template, redirect, request, session, flash
from flask_bcrypt import Bcrypt
from flask_app.models.user_model import User
from flask_app.models.recipe_model import Recipe


bcrypt = Bcrypt(app)


@app.route('/')
def index():
    if 'user_id' in session:
        # rediects to profile if user is logged in
        return redirect('/dashboard')
    return render_template("index.html")


@app.route('/users/register', methods=['POST'])
def user_reg():
    if not User.validator(request.form):
        # checks for valid registration
        return redirect('/')
        # redirects back if invalid
    hashed_pass = bcrypt.generate_password_hash(
        request.form['password'])  # hashes password
    data = {
        **request.form,
        'password': hashed_pass
    }
    user_id = User.create(data)
    # stores hash/accinfo in variable
    session['user_id'] = user_id
    user_in_db = User.get_by_email(data)
    print(user_in_db)
    session['user_name'] = user_in_db.first_name
    # puts user info in sessinon
    return redirect('/dashboard')


@app.route('/users/login', methods=['POST'])
def user_log():
    data = {
        'email': request.form['email']
    }
    user_in_db = User.get_by_email(data)
    if not user_in_db:
        # checking if email input is in database
        flash("invalid credentials", "log")
        return redirect('/')
    if not bcrypt.check_password_hash(user_in_db.password, request.form['password']):
        # checking if hashed password is correct
        flash('Invalid credentials', "log")
        return redirect('/')
    session['user_id'] = user_in_db.id
    session['user_name'] = user_in_db.first_name
    return redirect('/dashboard')


@app.route('/users/logout')
def log_out():
    del session['user_id']
    del session['user_name']
    # delete current session to logout
    return redirect('/')


@app.route('/dashboard')
def dash():
    if 'user_id' not in session:
        # sends user back to reg/log page if they're not logged in
        return redirect('/')
    user = Recipe.get_recipes()
    return render_template('welcome.html', user=user)
