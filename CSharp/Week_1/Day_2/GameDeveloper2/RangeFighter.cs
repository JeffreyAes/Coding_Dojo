class RangeFighter : Enemy
{
    int FieldDistance;
    public int _fieldDistance
    {
        get { return FieldDistance; }
        set { FieldDistance = value; }
    }

    public RangeFighter(int health = 100, int fieldDistance = 5) : base("RangeGoblin")
    {
        _health = health;
        _fieldDistance = fieldDistance;
        Attacks.Add(new Attack("arrow", 20));
        Attacks.Add(new Attack("knife throw", 15));
    }

    public bool DistanceCheck()
    {
        if (FieldDistance < 10)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void RangeAttack()
    {
        if (DistanceCheck())
        {
            Attack RangeAttack = base.RandomAttack();
            System.Console.WriteLine($"you used {RangeAttack.Name} dealing {RangeAttack.Damage} damage.");
        }
        else
        {
            System.Console.WriteLine("too close");
        }
    }

    public void Dash()
    {
        FieldDistance = 20;
        RangeAttack();
    }
}

