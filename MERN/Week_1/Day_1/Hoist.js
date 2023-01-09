// 1.)
console.log(hello);
var hello = 'world';

// var hello
// console.log(hello) = undefined
//hello = world

// output = undefined


// 2.)
var needle = 'haystack';
test();
function test() {
    var needle = 'magnet';
    console.log(needle);
}
// var needle
// function test() {
// var needle
// needle = 'magnet'
// console.log(foo) = magnet
// }
// needle = 'haystack'
// test()

// output = magnet


// 3.)
var brendan = 'super cool';
function print() {
    brendan = 'only okay';
    console.log(brendan);
}
console.log(brendan);

// var brendan
// function print() {
    //  brendan = 'only okay'
    // console.log(brendan) = 'only okay'
// }
// brendan = 'super cool'
// console.log(brendan) = 'super cool'
// output = 'super cool' 

// (function is never called, and never ran)


// 4.)
var food = 'chicken';
console.log(food);
eat();
function eat(){
    food = 'half-chicken';
    console.log(food);
    var food = 'gone';
}

// var food
// function eat() {
    // var food
    // food = 'half-chicken'
    // console.log(food) = half-chicken
    // food = 'gone'
// }
// food = 'chicken'
// console.log(food)=chicken
// eat()

// output = 'chicken' 'half-chicken'


// 5.)
console.log(mean)
mean();
console.log(food);
var mean = function() {
    food = "chicken";
    console.log(food);
    var food = "fish";
    console.log(food);
}
console.log(food);

// var mean = undefined
// mean()
// undefined is not a function

