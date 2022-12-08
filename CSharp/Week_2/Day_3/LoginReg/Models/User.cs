#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginReg.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
    public string FirstName { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "Password must be 8 characters long.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [Display(Name = "Confirm Password")]
    public string Confirm { get; set; }
}


public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Email is required.");
        }

        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if (_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email must be unique");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}