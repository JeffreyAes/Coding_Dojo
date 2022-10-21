var displayDiv = document.querySelector("#display");
displayDiv.innerText = "0";
// class operator
//id calculator
// id equals
var num1 = 0
var num2 = 0
var op = "0"
function press(num) {
    if (op == "0") {
        if (displayDiv.innerText == "0") {
            displayDiv.innerText = num
            num1 = parseFloat(displayDiv.innerText)
        }
        else {
            if (displayDiv.innerText.length < 9) {
                displayDiv.innerText += num
                num1 = parseFloat(displayDiv.innerText)
                console.log(num1)
            }
        }

    } else {
        if (displayDiv.innerText == "0") {
            displayDiv.innerText = num
            num2 = parseFloat(displayDiv.innerText)
        }
        else {
            if (displayDiv.innerText.length < 9) {
                displayDiv.innerText += num
                num2 = parseFloat(displayDiv.innerText)
            }
        }
    }
}
function setOP(operation) {
    op = operation
    displayDiv.innerText = "0"
}

function calculate() {
    if (op == "/") {
        displayDiv.innerText = num1 / num2
    }
    if (op == "+") {
        displayDiv.innerText = num1 + num2
    }
    if (op == "*") {
        displayDiv.innerText = num1 * num2
    }
    if (op == "-") {
        displayDiv.innerText = num1 - num2
    }
    num1 = parseFloat(displayDiv.innerText)
}


function clr() {
    num1 = 0
    num2 = 0
    displayDiv.innerText = 0
    op = 0
}

function lightUp(element) {
    element.classList.add("lightenUp")
}

function lightNone(element) {
    element.classList.remove("lightenUp")
}