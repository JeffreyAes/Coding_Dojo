Soda MySoda = new Soda(true, "coke", "brown", 38.3, 0);

Coffee MyCoffee = new Coffee("dark", "arabica", "black coffee");

Wine MyWine = new Wine("Bordeaux", 2001, "red wine", "red", 
62.3, 120);

List<Drink> AllBeverages = new List<Drink>();
AllBeverages.Add(MySoda);
AllBeverages.Add(MyCoffee);
AllBeverages.Add(MyWine);

foreach (Drink d in AllBeverages)
{
    d.ShowDrink();
}