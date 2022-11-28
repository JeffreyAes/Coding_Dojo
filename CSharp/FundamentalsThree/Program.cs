// See https://aka.ms/new-console-template for more information
static void PrintList(List<string> MyList)
{
    // Your code here
    foreach(string ListIndex in MyList){
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
PrintList(bikes);

static void SumOfNumbers(List<int> IntList)
{
    // Your code here
    int sum = 0;
    for(int i = 0; i<IntList.Count; i++){
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
    for(int i = 0; i < IntList.Count; i++){
        if (max < IntList[i]){
            max = IntList[i];
        }
    } Console.WriteLine(max);
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

    for(int i = 0; i < IntList.Count; i++){
        ReturnList.Add(IntList[i] * IntList[i]);
    } return(ReturnList);
}
List<int> Squarenumbers = new List<int>();
Squarenumbers.Add(2);
Squarenumbers.Add(3);
Squarenumbers.Add(5);
SquareValues(Squarenumbers);
