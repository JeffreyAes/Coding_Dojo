from flask_app import app
from flask import render_template, redirect, request, session, flash
from flask_bcrypt import Bcrypt
from flask_app.models.user_model import User
from flask_app.models.party_model import Party


@app.route('/parties/new')
def new_party():
    return render_template('party_new.html')


@app.route('/parties/create', methods=['POST'])
def create_party():
    if 'user_id' not in session:
        return redirect('/')
    if not Party.validator(request.form):
        return redirect('/parties/new')

    party_data = {
        **request.form,
        'user_id': session['user_id']
    }
    Party.create(party_data)
    return redirect('/dashboard')

@app.route('/parties/<int:id>/show')
def show_one(id):
    if 'user_id' not in session:
        return redirect('/')
    data = {
        'id':id
    }
    one_party = Party.get_by_id(data)
    return render_template('party_show.html', one_party=one_party)

@app.route('/parties/mine')
def my_recipes():
    if 'user_id' not in session:
        return redirect('/')
    logged_user = User.get_by_id({'id': session['user_id']})
    return render_template('my_parties.html', logged_user=logged_user)



@app.route('/parties/<int:id>/edit')
def edit_party(id):
    if 'user_id' not in session:
        return redirect('/')
    data = {
        'id': id
    }
    one_party = Party.get_by_id(data)

        
    return render_template('party_edit.html', one_party=one_party)

@app.route('/parties/<int:id>/update', methods=['POST'])
def update_party(id):
    if 'user_id' not in session:
        return redirect('/')
    if not Party.validator(request.form):
        return redirect('/parties/new')
    
    data = {
        'id': id, 
        **request.form
    }
    Party.update(data)
    Party.get_by_id(data)
    return redirect('/dashboard')

@app.route('/parties/<int:id>/delete')
def delete(id):
    if 'user_id' not in session:
        return redirect('/')
    data = {
        'id':id
    }
    Party.delete({'id':id})
    return redirect('/dashboard')


