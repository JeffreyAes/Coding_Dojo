﻿Product[] myProducts = new Product[]
{     
    new Product { Name = "Jeans", Category = "Clothing", Price = 24.7 },     
    new Product { Name = "Socks", Category = "Clothing", Price = 8.12 },     
    new Product { Name = "Scooter", Category = "Vehicle", Price = 99.99 },     
    new Product { Name = "Skateboard", Category = "Vehicle", Price = 24.99 },     
    new Product { Name = "Skirt", Category = "Clothing", Price = 17.5 }
};

IEnumerable<Product> sortProductsByPrice = myProducts.OrderBy(prod => prod.Price);
foreach (Product n in sortProductsByPrice)
{
    System.Console.WriteLine(n.Name);
}
    System.Console.WriteLine("============================");

IEnumerable<Product> orderedClothingProducts = myProducts.Where(c => c.Category == "Clothing").OrderByDescending(prod => prod.Price);
foreach (Product n in orderedClothingProducts)
{
    System.Console.WriteLine(n.Name);
}