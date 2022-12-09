using System.ComponentModel.DataAnnotations;
namespace DishesNChefs.Models;

public class OfAgeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("musn't be null");
        }
        DateTime today = DateTime.Today;
        DateTime birth = (DateTime)value;

        // Calculate the age.
        var age = today.Year - birth.Year;
        if (birth.Date > today.AddYears(-age)) age--;
        if (age < 18)
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Chef must be at least 18 years old.");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}