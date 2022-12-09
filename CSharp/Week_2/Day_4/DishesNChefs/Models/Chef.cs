#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DishesNChefs.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    [DataType(DataType.Date)]
    [Required]
    [PastDate]
    [OfAge]
    public DateTime? Birthday { get; set; }
    public List<Dish> AllDishes { get; set; } = new List<Dish>();
    public DateTime Created_At { get; set; } = DateTime.Now;
    public DateTime Updated_At { get; set; } = DateTime.Now;

}