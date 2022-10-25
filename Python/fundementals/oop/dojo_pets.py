class Ninja:
    # implement __init__( first_name , last_name , treats , pet_food , pet )
    def __init__(self, first_name, last_name, pet_name, treats, pet_food, pet):
        self.first_name = first_name
        self.last_name = last_name
        self.treats = treats
        self.pet_food = pet_food
        self.pet_name = pet_name
        self.action = pet

    # implement the following methods:
    def walk(self):
        print(f"{self.first_name} walks {self.pet_name}")
        self.action.play()
        return self

    def feed(self):
        print(f'{self.first_name} feeds {self.pet_name}')
        self.action.eat()
        return self

    def bathe(self):
        print(f'{self.first_name} bathes {self.pet_name}')
        self.action.noise()
        return self
    # walk() - walks the ninja's pet invoking the pet play() method
    # feed() - feeds the ninja's pet invoking the pet eat() method
    # bathe() - cleans the ninja's pet invoking the pet noise() method


class Pet:
    # implement __init__( name , type , tricks ):
    def __init__(self, name, type, tricks, health, energy):
        self.name = name
        self.type = type
        self.tricks = tricks
        self.health = health
        self.energy = energy

    def sleep(self):
        self.energy += 25
        print(f'{self.name} slept, new energy is {self.energy}')
        return self

    def eat(self):
        self.health += 10
        self.energy += 5
        print(f'{self.name} new health is {self.health} and energy is {self.energy}')
        return self

    def play(self):
        self.health += 5
        print(f'{self.name} new health is {self.health}')
        return self

    def noise(self):
        print(self.name)
        return self

    # implement the following methods:
    # sleep() - increases the pets energy by 25
    # eat() - increases the pet's energy by 5 & health by 10
    # play() - increases the pet's health by 5
    # noise() - prints out the pet's sound


ninja = Ninja("Jeffrey", "Aeschliman", "Nibbles", "milk bone", "dogfood",
Pet("Nibbles", "dog", "shake paw", 200, 255).sleep()).bathe().feed().walk()
print(ninja.pet_name)