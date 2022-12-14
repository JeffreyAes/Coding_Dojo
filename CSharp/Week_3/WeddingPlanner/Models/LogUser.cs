#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class LogUser
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string LEmail {get;set;}

    [Required]
    [MinLength(8, ErrorMessage = "Password must be 8 characters long.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string LPassword {get;set;}
}