from flask_app import app
from flask import render_template, redirect, request, session, flash
from flask_app.models.dojo_models import Dojo


@app.route('/')
def index():
    return redirect('/dojos')


@app.route('/dojos')
def dojos():
    dojos=Dojo.get_all()
    return render_template("dojos.html", dojos=dojos) 



@app.route("/insert_dojo", methods=["POST"])
def addDojo():
    Dojo.save(request.form)
    return redirect('/dojos')

@app.route('/dojos/<int:id>/show')
def show_dojo(id):
    one_dojo = Dojo.get_one({"id": id})
    return render_template("dojo_show_one.html", one_dojo=one_dojo)
