List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
Eruption? FirstChile = eruptions.FirstOrDefault(e => e.Location == "Chile");
System.Console.WriteLine($"first eruption in chile: {FirstChile}");

// ==================================================================

Eruption? FirstHawaii = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if (FirstHawaii != null)
{
System.Console.WriteLine($"first eruption in Hawaiian Island: {FirstHawaii}");
}
else 
{
    System.Console.WriteLine("No Hawaiian Is Eruption found.");
}

// ==================================================================

Eruption? FirstGreenland = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if (FirstGreenland != null)
{
System.Console.WriteLine($"first eruption in Greenland: {FirstGreenland}");
}
else 
{
    System.Console.WriteLine("No Greenland Eruption found.");
}

// ==================================================================

Eruption? FirstNewZeaBefore = eruptions.Where(c => c.Year > 1900).FirstOrDefault(z => z.Location == "New Zealand");
System.Console.WriteLine($"first new zealand eruption after year 1900: {FirstNewZeaBefore}");


// ==================================================================

IEnumerable<Eruption> ElevationOver2k = eruptions.Where(c => c.ElevationInMeters > 2000);
PrintEach(ElevationOver2k, "volcanos over 2k meters elevation: ");


// ==================================================================

IEnumerable<Eruption> StartWithL = eruptions.Where(c => c.Volcano.StartsWith('L'));
PrintEach(StartWithL, "volcanos that start with L: ");


// ==================================================================

int? MaxElevation = eruptions.Max(m => m.ElevationInMeters);
System.Console.WriteLine($"Max elevation: {MaxElevation}");


// ==================================================================

Eruption? HighestElVolcano = eruptions.FirstOrDefault(v => v.ElevationInMeters== MaxElevation);
System.Console.WriteLine($"Highest elevation volcano: {HighestElVolcano}");


// ==================================================================

IEnumerable<Eruption> AlphabeticalEruptions = eruptions.OrderBy(v => v.Volcano);
PrintEach(AlphabeticalEruptions, "Alhphabetical eruptions. :)");


// ==================================================================

int? sumElevations = eruptions.Sum(s => s.ElevationInMeters);
System.Console.WriteLine($"Sum of elevations: {sumElevations}") ;


// ==================================================================

bool IsEruptedAfter2000 = eruptions.Any(v => v.Year == 2000);
System.Console.WriteLine($"were there eruptions in the year 2000: {IsEruptedAfter2000}");


// ==================================================================

IEnumerable<Eruption> firstThree = eruptions.Take(3);
PrintEach(firstThree, "first three eruptions: ");



// ==================================================================

IEnumerable<Eruption> BeforeYear1000 = eruptions.Where(y => y.Year < 1000).OrderBy(a => a.Volcano);
PrintEach(BeforeYear1000, "Eruptions before the year 1000: ");

List<string> BeforeYear1000Names = eruptions.Where(y => y.Year < 1000).OrderBy(a => a.Volcano).Select(a => a.Volcano).ToList();
foreach (string n in BeforeYear1000Names)
{
    System.Console.WriteLine($"These are just the names: {n}");
}





// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}