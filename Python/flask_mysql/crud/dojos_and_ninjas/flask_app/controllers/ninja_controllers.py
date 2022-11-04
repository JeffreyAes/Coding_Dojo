from flask_app import app
from flask import render_template, redirect, request, session, flash
from flask_app.models.dojo_models import Dojo
from flask_app.models.ninja_models import Ninja

@app.route('/ninjas/new')
def new_ninja():
    all_dojos = Dojo.get_all()
    return render_template("ninja_new.html", all_dojos=all_dojos )

@app.route('/ninjas/create', methods=['POST'])
def create_ninja():
    Ninja.save(request.form)
    return redirect(f"/dojos/{request.form['dojo_id']}/show")