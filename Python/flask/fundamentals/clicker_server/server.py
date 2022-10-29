from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)
app.secret_key = 'meme' # set a secret key for security purposes

@app.route('/')
def enter_site():
    if 'num' in session:    #checking if num is already in session
        session['num'] += 1 #adds 1 everytime you enter the site
    else:
        session['num'] = 1  #creates session['num'] which acts like a dictionary, and sets it to 1
    return render_template('index.html', num=session['num'])    #puts session[num] in a variable called 'num'

@app.route('/count')    #directed here when the increase button is clicked
def start_count():
    session['num'] +=1
    return redirect('/')    #adds 1 to session['num'], then redirects back to route which also adds 1
                            #which essentially adds 2 to num

@app.route('/destroy_session') #directed here when the reset button is clicked
def destroy_count():
    session['num'] = 0  #sets the session['num'] to zero (resetting it)
    return redirect('/')    #directs you back to the root, adding 1 back to the count

@app.route('/<int:num>')    #user inputs an (integer) to the route
def add_count(num): #takes from the inputed integer and puts it in the paramater
    if 'num' in session:    #checks if num is already in session
        session['num'] += num   #adds the inputed integer to session ['num']
    else:
        session['num'] = 1  #sets session['num'] to 1
    return render_template('index.html', num=session['num']) #renders index html, puts session['num'] in variable num



if __name__ == "__main__":
    app.run(debug=True)