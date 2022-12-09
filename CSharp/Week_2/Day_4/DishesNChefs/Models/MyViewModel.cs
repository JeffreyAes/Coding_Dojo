#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DishesNChefs.Models;
public class MyViewModel
{
    public Chef chef {get;set;}
    public List<Chef> AllChefs {get;set;}
    public Dish Dish {get;set;}
    public List<Dish> AllDishes {get;set;}
}