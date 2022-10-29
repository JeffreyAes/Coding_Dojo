from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)

app.secret_key = 'meme'


@app.route('/')
def index():
    return render_template('index.html')

@app.route('/process', methods=["POST"])
def process():
    session['name'] = request.form['name']
    session['location'] = request.form['location']
    session['language'] = request.form['language']
    session['text_area'] = request.form['text_area']
    print(request.form)
    return redirect('/result')

@app.route('/result')
def result():

    return render_template('result.html')

if __name__ == "__main__":
    app.run(debug=True)