var count = 3;
var countElement = document.querySelector("#likes")

console.log(countElement)
function addLike() {
    count++;
    countElement.innerText = count + " like(s)";
    console.log(count)
}