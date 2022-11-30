MeleeFighter BoxerGoblin = new MeleeFighter();
RangeFighter RangeGoblin = new RangeFighter();
MagicCaster MagicGoblin = new MagicCaster();
List<Enemy> AllEnemies = new List<Enemy>();
AllEnemies.Add(BoxerGoblin);
AllEnemies.Add(RangeGoblin);
AllEnemies.Add(MagicGoblin);
foreach (Enemy e in AllEnemies)
{
    e.ShowEnemies();
}
BoxerGoblin.Rage();

RangeGoblin.RangeAttack();
RangeGoblin.Dash();

MagicGoblin.heal(MagicGoblin);
MagicGoblin.heal(RangeGoblin);
MagicGoblin.heal(BoxerGoblin);