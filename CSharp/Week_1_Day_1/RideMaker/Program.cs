Vehicle Horse = new Vehicle("Ed", 2, "brown", false, 20);
System.Console.WriteLine(Horse.Name);

Vehicle toyota = new Vehicle("toyota", 5, "red", true, 140);

Vehicle Bike = new Vehicle("Bike", 2, "green", false, 20);

Vehicle Truck = new Vehicle("Truck", 6, "Blue", true, 100);

List<Vehicle> AllVehicles = new List<Vehicle>();
AllVehicles.Add(Horse);
AllVehicles.Add(toyota);
AllVehicles.Add(Bike);
AllVehicles.Add(Truck);

foreach (Vehicle v in AllVehicles)
{
    v.ShowInfo();
}

Bike.Travel(100);
Bike.Travel(100);

Bike.ShowInfo();