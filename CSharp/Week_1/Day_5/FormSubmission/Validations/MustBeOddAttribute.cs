using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;

public class MustBeOddAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)    
    {   
        if(value == null)
        {
            return new ValidationResult("musn't be null");
        }
        // We are expecting the value coming in to be a string
        // so we need to do a bit of type casting to our object
        // Strings work similarly to arrays under the hood 
        // so we can grab the first letter using its index   
        // If we discover that the first letter of our string is z...  
        if ((int)value % 2 == 0)
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Must be odd");   
        } else {   
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }  
    }
}