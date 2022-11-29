class Coffee : Drink
{
    public string Roast;
    public string BeanType;

    public Coffee(string roast, string bean, string name) : base(name, "brown", 200.1, false, 0 )
    {
        Roast = roast;
        BeanType = bean;
        name = Name;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        System.Console.WriteLine($"Roast: {Roast}");
        System.Console.WriteLine($"Bean: {BeanType}");
    }
}