function removeCookie() {
    document.getElementById(cookie)
    cookie.remove();
}

function celToFahr(element) {
    var num = document.querySelectorAll(".val")
    for (var i = 0; i < num.length; i++) {
        if (element.value == "°F") {
            num[i].innerText = (parseInt(num[i].innerText) * (9 / 5) + 32).toFixed(0)
            console.log(num[i])
        } else {
            num[i].innerText = ((parseInt(num[i].innerText) - 32) * 5 / 9).toFixed(0)
        }
    }
}
