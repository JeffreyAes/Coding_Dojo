class Wine : Drink
{
    public string Region;
    public int YearBottled;

    public Wine(string region, int year, 
    string name, string color, double temp, int calories) 
    : base(name, color, temp, false, calories )
    {
        Region = region;
        YearBottled = year;
        name = Name;
        color = Color;
        temp = Temperature;
        calories = Calories;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        System.Console.WriteLine($"Region: {Region}");
        System.Console.WriteLine($"Year: {YearBottled}");
    }
}