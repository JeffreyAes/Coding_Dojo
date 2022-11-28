// See https://aka.ms/new-console-template for more information
static void PrintList(List<int> MyList)
{
    // Your code here
    foreach (int ListIndex in MyList)
    {
        Console.WriteLine(ListIndex);
    }
}
List<string> bikes = new List<string>();
// Use the Add function in a similar fashion to push
bikes.Add("Kawasaki");
bikes.Add("Triumph");
bikes.Add("BMW");
bikes.Add("Moto Guzzi");
bikes.Add("Harley Davidson");
bikes.Add("Suzuki");
// PrintList(bikes);

static void SumOfNumbers(List<int> IntList)
{
    // Your code here
    int sum = 0;
    for (int i = 0; i < IntList.Count; i++)
    {
        sum = sum += IntList[i];
    }
    Console.WriteLine(sum);

}
List<int> numbers = new List<int>();
numbers.Add(2);
numbers.Add(3);
numbers.Add(5);
SumOfNumbers(numbers);

static void FindMax(List<int> IntList)
{
    // Your code here
    int max = IntList[0];
    for (int i = 0; i < IntList.Count; i++)
    {
        if (max < IntList[i])
        {
            max = IntList[i];
        }
    }
    Console.WriteLine(max);
}

List<int> Maxnumbers = new List<int>();
Maxnumbers.Add(2);
Maxnumbers.Add(3);
Maxnumbers.Add(5);
Maxnumbers.Add(1);
Maxnumbers.Add(7);
Maxnumbers.Add(4);
FindMax(Maxnumbers);

static List<int> SquareValues(List<int> IntList)
{
    // Your code here
    List<int> ReturnList = new List<int>();

    for (int i = 0; i < IntList.Count; i++)
    {
        ReturnList.Add(IntList[i] * IntList[i]);
        // Console.WriteLine(ReturnList[i]);
    }
    // Console.WriteLine(ReturnList.Count);
    return ReturnList;
}
List<int> Squarenumbers = new List<int>();
Squarenumbers.Add(2);
Squarenumbers.Add(3);
Squarenumbers.Add(5);
// Console.WriteLine(SquareValues(Squarenumbers));
PrintList(SquareValues(Squarenumbers));


static int[] NonNegatives(int[] IntArray)
{
    // Your code here
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;

        }
        Console.WriteLine(IntArray[i]);
    }
    return IntArray;
}
int[] NegativeArray;
NegativeArray = new int[] { 1, -1, 2, -5, -8, 5, -6, 7, 9 };
// Console.WriteLine(NegativeArray);
NonNegatives(NegativeArray);


// changed to <string,int> so i can call it for the last one.
static void PrintDictionary(Dictionary<string, int> MyDictionary)
{
    // Your code here
    foreach (KeyValuePair<string, int> item in MyDictionary)
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}

Dictionary<string, string> profile = new Dictionary<string, string>();
profile.Add("Name", "Sandra");
profile.Add("Language", "C#");
profile.Add("Location", "England");
// PrintDictionary(profile);


static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    // Your code here
    foreach (KeyValuePair<string, string> item in MyDictionary)
    {
        if (item.Key == SearchTerm)
        {
            return true;
        }
    }
    return false;

}

Console.WriteLine(FindKey(profile, "Language"));
Console.WriteLine(FindKey(profile, "Lanuage"));

static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    // Your code here
    int i = 0;
    Dictionary<string, int> ReturnDictionary = new Dictionary<string, int>();
    foreach (string index in Names)
    {
        ReturnDictionary.Add(index, Numbers[i]);
        i++;

    }
    foreach (KeyValuePair<string, int> item in ReturnDictionary)
    {
        // Console.WriteLine($"{item.Key} - {item.Value}");
    }
    return ReturnDictionary;
}

PrintDictionary(GenerateDictionary(bikes, Maxnumbers));