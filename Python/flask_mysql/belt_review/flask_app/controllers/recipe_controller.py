from flask_app import app
from flask import render_template, redirect, request, session, flash
from flask_app.models.user_model import User
from flask_app.models.recipe_model import Recipe


@app.route('/recipe/new')
def new_recipe():
    return render_template('create_recipe.html')

@app.route('/recipe/create', methods=['POST'])
def create_recipe():
    Recipe.recipeSave(request.form)
    return redirect('/dashboard')

