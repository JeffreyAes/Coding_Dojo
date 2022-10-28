from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)
app.secret_key = 'meme' # set a secret key for security purposes

@app.route('/')
def enter_site():
    if 'num' in session:
        session['num'] += 1
    else:
        session['num'] = 1
    return render_template('index.html', num=session['num'])

@app.route('/count')
def start_count():
    session['num'] +=1
    return redirect('/')

@app.route('/destroy_session')
def destroy_count():
    session['num'] = 0
    return redirect('/')

@app.route('/<int:num>')
def add_count(num):
    if 'num' in session:
        session['num'] += num 
    else:
        session['num'] = 1
    return render_template('index.html', num=session['num'])



if __name__ == "__main__":
    app.run(debug=True)