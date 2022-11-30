class MeleeFighter : Enemy
{
    public MeleeFighter(int health = 120) : base("BoxerGoblin")
    {
        _health = health;
        Attacks.Add(new Attack("punch", 20));
        Attacks.Add(new Attack("kick", 15));
        Attacks.Add(new Attack("tackle", 25));
    }
    public void Rage()
    {
        Attack RageAttack = base.RandomAttack();
        RageAttack.Damage += 10;
        System.Console.WriteLine($"you used {RageAttack.Name} dealing {RageAttack.Damage} damage.");
    }
}