class Soda : Drink
{
    public bool IsDiet;
    public Soda(bool diet, string name, string color, double temp, int calories) : base(name, color, temp, true, calories)
    {
        IsDiet = diet;
        name = Name;
        color = Color;
        temp = Temperature;
        calories = Calories;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        System.Console.WriteLine($"Diet: {IsDiet}");
    }
}