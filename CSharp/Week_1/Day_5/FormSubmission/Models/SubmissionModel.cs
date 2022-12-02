using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models;
public class Submission
{
    [Required(ErrorMessage = "Name is Required")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
    public string Name {get;set;}

    [Required(ErrorMessage = "Email is Required")]
    [EmailAddress(ErrorMessage = "Must be a valid email")]
    public string Email {get;set;}

    [Required(ErrorMessage = "Birthday is Required")]
    [PastDate]
    public DateTime? Birthday {get;set;}

    [Required(ErrorMessage = "Password is Required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password {get;set;}

    [Required(ErrorMessage = "Prime number is Required")]
    [PrimeNumber]
    public int? OddNum {get;set;}
}