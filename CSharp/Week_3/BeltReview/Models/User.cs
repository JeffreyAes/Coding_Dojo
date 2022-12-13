#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltReview.Models;
public class User
{
    [Key]
    public int UserId {get;set;}


    [Required]
    [MinLength(2, ErrorMessage = "Username must be at least 2 characters long.")]
    public string Username {get;set;}


    [EmailAddress]
    [UniqueEmail]
    [Required]
    public string Email {get;set;}


    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
    [DataType(DataType.Password)]
    public string Password{get;set;}

// This is for my one to many!
public List<Craft> Listings {get;set;} = new List<Craft>();

// This is for my MANY to MANY
public List<Order> OrdersPlaced {get;set;} = new List<Order>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPass {get;set;}
}