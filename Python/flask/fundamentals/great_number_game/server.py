from flask import Flask, render_template, request, redirect, session
import random

app = Flask(__name__)
# set a secret key for security purposes@app.route('/')
app.secret_key = 'meme'     #required


@app.route('/')
def guess_number(): 
    if 'random' in session:        #IF random was put into a session backpack, set it to itsef
        session['random'] = session['random']   #this keeps it from creating a new random integer each time it redirects/refresh
    else:
        session['random'] = random.randint(1, 100)  #puts the random number in the session backpack
    session['answer'] = session['answer']   #not sure lol
    return render_template('index.html')    #renders the html for users to give guesses


# checks if guess is correct and redirects back with feedback

@app.route('/response',  methods=['POST'])  #guesses are stored and then sent to here through POST method

def check_guess():  #checking if guess is greater/less than the random integer

    session['count'] = 0    #i think this is why it didn't work

    session['guess'] = int(request.form['guess'])   
    #taking the information from the POST, grabbing the [guess] key and
    #putting it in a session['guess'] backpack

    answer = "" #empty string to insert text to, given the conditionals met below

    if session['random'] < session['guess']:    #asking if guess is more or less
        answer = "WAYYYYY too big"  #puts feed back in empty sting
    elif session['random'] > session['guess']:
        answer = "too small"
    else:
        answer = "cORRECT!"
        session['random'] = random.randint(1,100)
    session['answer'] = answer
    if session['guess'] != session['random']:
        session['count'] =0
    return redirect('/')


if __name__ == "__main__":
    app.run(debug=True)
