class Ninja {
    constructor(name, health = 5, strength = 3, speed = 3) {
        this.name = name;
        this.health = health;
        this.strength = strength;
        this.speed = speed;
    }

    sayName() {
        console.log(this.name)
    }
    showStats() {
        console.log(this.name)
        console.log(this.health)
        console.log(this.strength)
        console.log(this.speed)
    }
    drinkSake() {
        this.health += 10
        console.log(this.health)
    }
}
const ninja1 = new Ninja("Hyabusa");
ninja1.sayName();
ninja1.showStats();
ninja1.drinkSake();
ninja1.showStats();