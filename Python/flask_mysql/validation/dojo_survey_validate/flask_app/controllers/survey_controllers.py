from flask_app import app
from flask import render_template, redirect, request, session, flash
from flask_app.models.survey_models import Survey

@app.route('/') 
def index():
    session.clear()
    return redirect('/survey')   

@app.route('/survey')
def survey():
    return render_template("index.html")

@app.route("/insert_user", methods=["POST"])
def addUser():
    if not Survey.validate_survey(request.form):
        return redirect('/survey')
    print(request.form)
    data = {
        **request.form
    }
    in_session = Survey.save(data)
    # Survey.get_one()
    session['id'] = in_session
    print(session['id'])
    return redirect('/results/show')


@app.route('/results/show')
def result():
    # one_user = Survey.get_one({"id" : id})
    data={
        'id' : session['id']
    }
    in_session = Survey.get_one(data)
    return render_template('result.html', in_session=in_session)   
