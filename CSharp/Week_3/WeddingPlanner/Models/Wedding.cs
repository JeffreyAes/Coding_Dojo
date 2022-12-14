#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class Wedding
{
    [Key]
    public int WeddingId {get;set;}
    [Required]
    public string WedderOne {get;set;}
    [Required]
    public string WedderTwo {get;set;}
    [Required]
    public string Address {get;set;}
    [Required]
    [FutureDate]
    [DataType(DataType.Date)]
    public DateTime? PlanDate {get;set;}
    // required for building one to many relationship
    public int UserId {get;set;}

    // navigation for pulling information of the user connected
    // (one to many)
    public User? Planner {get;set;}

    // this is required for reaching across the extra table in many to many
    // (many to many)
    public List<Guest> Guests {get;set;} = new List<Guest>(); 

    
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}

