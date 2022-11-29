class Enemy {
    public string Name;
    int Health =100;
    public int _health
    {
        get {return Health;}
    }
    public List<Attack> Attacks;

    public Enemy(string n)
    {
        Name = n;
        Attacks = new List<Attack>();
    }


}