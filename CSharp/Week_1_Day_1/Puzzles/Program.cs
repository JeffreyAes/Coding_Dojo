static string FlipCoin()
{
    Random rand = new Random();
    int randomInt = rand.Next(0, 2);
    if (randomInt == 0)
    {
        return "heads";
    }
    else
    {
        return "tails";
    }
}
Console.WriteLine(FlipCoin());



// static int RollDie(int sides)
// {

//     Random rand = new Random();

//     int DieRoll = rand.Next(1, sides);
//     Console.WriteLine("=============");
//     return DieRoll;
// }

// Console.WriteLine("how many sides on your die?");
// string NumberInput = Console.ReadLine();
// if (Int32.TryParse(NumberInput, out int sides))
// {
//     Console.WriteLine(RollDie(sides));
// }


static string RollDieUntil(int sides, int target, int attempts = 1)
{
    if (target > sides || target <= 0)
    {
        return "not good, run again.";
    }
    Random rand = new Random();

    int DieRoll = rand.Next(1, sides + 1);
    if (DieRoll != target)
    {
        attempts++;
        return RollDieUntil(sides, target, attempts);
    }
    else
    {
        return ($"you rolled: {DieRoll} in: {attempts} attempts");
    }
}

Console.WriteLine("how many sides on your die?");
string NumberInput = Console.ReadLine();
if (Int32.TryParse(NumberInput, out int sides))
{
    Console.WriteLine("what shall be your final roll?");
    string NumberInput2 = Console.ReadLine();
    if (Int32.TryParse(NumberInput2, out int target))
    {
        Console.WriteLine(RollDieUntil(sides, target));
    }
}


