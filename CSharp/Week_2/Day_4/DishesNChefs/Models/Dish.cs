#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DishesNChefs.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1,5)]
    public int? Tastiness { get; set; }
    [Required]
    [Range(1,int.MaxValue)]
    public int? Calories { get; set; }
    [ForeignKeyReq]
    public int ChefId {get;set;}
    public Chef? Creator {get;set;}
    public DateTime Created_At { get; set; } = DateTime.Now;
    public DateTime Updated_At { get; set; } = DateTime.Now;
}