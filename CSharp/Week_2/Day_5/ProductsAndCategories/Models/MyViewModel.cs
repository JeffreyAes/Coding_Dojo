#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;
public class MyViewModel
{
    public Product? ViewProduct {get;set;}
    public List<Product> AllViewProduct {get;set;}
    public Category ViewCategory {get;set;}
    public List<Category> AllViewCategory {get;set;}
    // good luck with this one
    // Terrance solved the algo today
}