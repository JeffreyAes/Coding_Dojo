from flask import Flask, render_template, request, redirect, session
import random

app = Flask(__name__)
# set a secret key for security purposes@app.route('/')
app.secret_key = 'meme'


@app.route('/')
def guess_number():
    if 'random' in session:
        session['random'] = session['random']
    else:
        session['random'] = random.randint(1, 100)
    session['answer'] = session['answer']
    return render_template('index.html')


# checks if guess is correct and redirects back with feedback
@app.route('/response',  methods=['POST'])
def check_guess():
    session['guess'] = int(request.form['guess'])
    answer = ""
    if session['random'] < session['guess']:
        answer = "WAYYYYY too big"
    elif session['random'] > session['guess']:
        answer = "too small"
    else:
        answer = "cORRECT!"
        session['random'] = random.randint(1,100)
    session['answer'] = answer
    
    return redirect('/')


if __name__ == "__main__":
    app.run(debug=True)
