var count = 9;
var countElement = document.querySelector("#likes")

console.log(countElement)
function addLike() {
    count++;
    countElement.innerText = count + " like(s)";
    console.log(count)
}

var count2 = 12;
var countElement2 = document.querySelector("#likes2")
function addLike2(){
count2++;
countElement2.innerText = count2 + " like(s)";
}

var count3 = 9;
var countElement3 = document.querySelector("#likes3")
function addLike3(){
    count3++;
    countElement3.innerText = count3 + " like(s)"
}