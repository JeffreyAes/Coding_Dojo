// See https://aka.ms/new-console-template for more information

// arrays
int[] ArrayOne;
ArrayOne = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
foreach (int number in ArrayOne)
{
    Console.WriteLine(number);
}

string[] ArrayTwo = new string[] { "Tim", "Martin", "Nikki", "Sara" };
foreach (string name in ArrayTwo)
{
    Console.WriteLine(name);
}

bool[] ArrayThree = new bool[10];
for (int i = 0; i < ArrayThree.Length; i++)
{
    if (i % 2 != 0)
    {
        ArrayThree[i] = true;

    }
    else
    {
        ArrayThree[i] = false;
    }
    Console.WriteLine(ArrayThree[i]);
}



// lists
List<string> icecream = new List<string>();
icecream.Add("chocolate");
icecream.Add("vanilla");
icecream.Add("rockyroad");
icecream.Add("strawberry");
icecream.Add("mint chocolate chip");
Console.WriteLine(icecream.Count);
Console.WriteLine(icecream[2]);
icecream.RemoveAt(2);
Console.WriteLine(icecream.Count);
Random rand = new Random();



// dictionaries
Dictionary<string, string> favorites = new Dictionary<string, string>();
favorites.Add(ArrayTwo[0], icecream[2]);
favorites.Add(ArrayTwo[1], icecream[1]);
favorites.Add(ArrayTwo[2], icecream[3]);
favorites.Add(ArrayTwo[3], icecream[0]);
foreach (KeyValuePair<string, string> fav in favorites)
{
    Console.WriteLine($"{fav.Key} - {fav.Value}");

}
