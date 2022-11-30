class Enemy
{
    public string Name;
    private int Health = 100;
    public int _health
    {
        get { return Health; }
        set { Health = value; }
    }
    public List<Attack> Attacks;


    public Enemy(string n)
    {
        Name = n;
        Attacks = new List<Attack>();
    }

    public virtual void ShowEnemies()
    {
        System.Console.WriteLine(Name);
    }

    public Attack RandomAttack()
    {
        Random rand = new Random();
        int RandomAttack = rand.Next(0, this.Attacks.Count);
        return this.Attacks[RandomAttack];
    }
    



}