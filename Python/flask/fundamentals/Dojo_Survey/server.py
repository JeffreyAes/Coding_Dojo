from flask import Flask, render_template, request, redirect, session  

app = Flask(__name__)

app.secret_key = 'meme' #required for sessions


@app.route('/') 
def index():
    return render_template('index.html')    #display the form for user to input info

@app.route('/process', methods=["POST"])    #once submitted it stores and sends the form through the post method
def process():                              #the post form creates a dictonary called request.form
    session['name'] = request.form['name']    #now we put the request.form[key] into a session[key] 
    session['location'] = request.form['location']    #(put info in backpack for reuse)
    session['language'] = request.form['language']
    session['text_area'] = request.form['text_area']
    print(request.form)   #checking if request.form posted correctly (shouldn't show the input)
    return redirect('/result')    #directs you to the result route

@app.route('/result')
def result():

    return render_template('result.html')    #displays the post request information in html table

if __name__ == "__main__":
    app.run(debug=True)