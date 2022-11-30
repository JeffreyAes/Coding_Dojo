class MagicCaster : Enemy
{
    public MagicCaster(int health=80) : base("MagicGoblin")
    {
        _health = health;
        Attacks.Add(new Attack("Fireball", 25));
        Attacks.Add(new Attack("Shield", 0));
        Attacks.Add(new Attack("staff strike", 15));
    }

    public void heal(Enemy target)
    {
        target._health += 40;
        System.Console.WriteLine($"You healed {target.Name}, their health is now {target._health}");
    }
}