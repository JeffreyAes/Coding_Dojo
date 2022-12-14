#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class User
{
    [Key]
    public int UserId {get;set;}

    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email {get;set;}
    [DataType(DataType.Password)]
    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
    public string Password {get;set;}

    // navigate to the many side of the one to many.
    public List<Wedding> PlannedWeddings {get;set;} = new List<Wedding>();

    // Navigate to the extra table in the many to many.
    public List<Guest> Attending {get;set;} = new List<Guest>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string Confirm {get;set;}
}