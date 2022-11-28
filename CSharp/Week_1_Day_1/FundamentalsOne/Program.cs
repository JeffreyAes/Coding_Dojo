// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}

Random rand = new Random();
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(rand.Next(10, 21));
}

for (int i = 1; i <= 100; i++)
{
    if (i % 15 != 0)
    {
        if (i % 3 == 0 || i % 5 == 0)
        {
            Console.WriteLine(i);
        }

    }
}

for (int i = 1; i <= 100; i++)
{
    if (i % 15 != 0)
    {
        if (i % 3 == 0)
        {
            Console.WriteLine("fizz");
        }
        if (i % 5 == 0)
        {
            Console.WriteLine("buzz");
        }


    }
}

for (int i = 1; i <= 100; i++)
{
    if (i % 15 == 0)
    {
        Console.WriteLine("fizzbuzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("fizz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("buzz");
    }
    else
    {
        Console.WriteLine(i);
    }


}


