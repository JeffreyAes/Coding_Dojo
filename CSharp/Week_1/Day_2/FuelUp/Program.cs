﻿// SOLUTION PROJECT FOR C# ASSIGNMENT - FUEL UP!
// DO NOT COPY FOR ASSIGNMENT SUBMISSION
// TRY THE ASSIGNMENT BEFORE COMING HERE

// Create 4 vehicles using each constructor at least once
Car car = new Car("Nissan Frontier", 5, "Red", 120, "Gas");
Bike bicycle = new Bike("Schwinn", "Silver", 30);
Horse horse = new Horse("Donna", "Brown", 20, "Hay");
Rocket rocket = new Rocket("Elon Ship", 5, "red", 500, "nuclear goo thing");
// This causes a problem because Vehicle is abstract now
// Vehicle scooter = new Vehicle("Scooter", "Black");

// Put all the vehicles created into a List
List<Vehicle> AllVehicles = new List<Vehicle>();
AllVehicles.Add(car);
AllVehicles.Add(bicycle);
AllVehicles.Add(horse);
AllVehicles.Add(rocket);

// Create a List of INeedFuel, but do not add anything to it yet
List<INeedFuel> NeedsFuel = new List<INeedFuel>();

// Loop through the List of Vehicles and if an item has the INeedFuel interface applies, add it to the INeedFuel List
foreach(Vehicle v in AllVehicles)
{
    if(v is INeedFuel)
    {
        NeedsFuel.Add((INeedFuel)v);
    }
}

// Take your finished INeedFuel List, loop through it, and give each item 10 units of fuel
foreach(INeedFuel i in NeedsFuel)
{
    i.GiveFuel(10);
}