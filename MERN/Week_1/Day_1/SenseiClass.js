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
        return ("you used drink sake, your new health is " + this.health + "!")
    }
}
const ninja1 = new Ninja("Hyabusa");
ninja1.sayName();
ninja1.showStats();
console.log(ninja1.drinkSake());
ninja1.showStats();

class Sensei extends Ninja{
    constructor(name, health=30, strength=10, speed=10, wisdom=10){
        super(name, health, strength, speed);
        this.wisdom = wisdom
    }
    speakWisdom(){
        const Wisdom = super.drinkSake();
        console.log(Wisdom, "Quote of wisdom: What one programmer can do in one month, two programmers can do in two months.")
    }

}

const superNinja = new Sensei("GigaNinja");
superNinja.sayName();
superNinja.showStats();
superNinja.speakWisdom();
superNinja.showStats();
