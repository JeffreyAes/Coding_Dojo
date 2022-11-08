from flask_app import app
from flask import render_template, redirect, request, session, flash
from flask_bcrypt import Bcrypt
from flask_app.models.user_model import User
from flask_app.models.recipe_model import Recipe

@app.route('/recipe/new')
def new_recipe():
    return render_template("recipe_create.html")

@app.route('/recipes/create', methods=['POST'])
def create_recipe():
    if 'user_id' not in session:
        return redirect ('/')
        #users who are not logged in cannot create recipes, and will be returned back to index
    if not Recipe.validator(request.form):
        return redirect('/recipe/new')
        #invalid information will not be submitted, and user will be redirected back to the form.
    recipe_data = {
        **request.form,
        'user_id': session['user_id']
    }
    Recipe.create(recipe_data)
    return redirect('/dashboard')
    #creates the recipe, and sends the user_id to use

@app.route('/recipe/<int:id>/show')
def show_one_recipe(id):
    if 'user_id' not in session:
        return redirect ('/')
    data = {
        'id': session['user_id']
    }
    logged_user = User.get_by_id(data)
    #stores session id in logged_user to use in the html
    this_recipe = Recipe.get_by_id({'id':id})
    return render_template("recipe_one.html", this_recipe=this_recipe, logged_user=logged_user) 
    #shows a single recipe, and its information

@app.route('/recipes/mine')
def show_my_recipes():
    if 'user_id' not in session:
        return redirect ('/')
    logged_user = User.get_by_id({'id': session['user_id']})
    return render_template('my_recipes.html', logged_user=logged_user)
    #shows all of the recipes of specified user


@app.route('/recipe/<int:id>/edit')
def edit_form(id):
    if 'user_id' not in session:
        return redirect ('/')
    data = {
        'id': id
    }
    one_recipe = Recipe.get_by_id(data)
    this_recipe = Recipe.get_by_id(data)
    if not this_recipe.user_id == session['user_id']:
        flash("HEY! that's not your recipe!")
        return redirect('/dashboard')
        #takes the id, compares it to id in session, and if they do not match it stops them from maliciously editing another
        #users recipe, sends them to the dashboard with a message.
    return render_template('recipe_edit.html', one_recipe=one_recipe)
    #grabs recipe by it's id, and directs user to an edit page

@app.route('/recipe/<int:id>/update', methods=['POST'])
def update_recipe(id):
    if 'user_id' not in session:
        return redirect ('/')
    if not Recipe.validator(request.form):
        return redirect(f"/recipe/{id}/edit")
    
    data = {
        'id':id,
        **request.form  
    }
    recipe_to_update = Recipe.get_by_id(data)
    if not recipe_to_update.user_id == session['user_id']:
        flash("well well, someone thinks they're clever huh")
        return redirect('/dashboard')
    Recipe.update(data)
    return redirect('/dashboard')

@app.route('/recipe/<int:id>/delete')
def del_recipe(id):
    if 'user_id' not in session:
        return redirect ('/')
    data = {
        'id':id
    }
    this_recipe = Recipe.get_by_id(data)
    if not this_recipe.user_id == session['user_id']:
        flash("HEY! that's not your recipe!")
        return redirect('/dashboard')
    Recipe.delete({'id':id})
    return redirect('/dashboard')


