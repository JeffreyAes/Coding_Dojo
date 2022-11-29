Enemy Goblin = new Enemy("Greg the Goblin");
System.Console.WriteLine(Goblin.Name);
System.Console.WriteLine((Goblin._health));
Attack Punch = new Attack("Punch", 30);
Attack Kick = new Attack("Kick", 50);
Attack Stab = new Attack("Stab", 100);
System.Console.WriteLine(Stab.Damage);
System.Console.WriteLine(Kick.Name);
System.Console.WriteLine(Punch.Damage);

Goblin.Attacks.Add(Punch);
Goblin.Attacks.Add(Kick);
Goblin.Attacks.Add(Stab);
Random rand = new Random();
int RandomAttack = rand.Next(0, Goblin.Attacks.Count);
System.Console.WriteLine(Goblin.Attacks[RandomAttack].Name);