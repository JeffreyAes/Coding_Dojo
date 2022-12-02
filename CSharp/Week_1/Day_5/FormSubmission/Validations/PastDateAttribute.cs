using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;

public class PastDateAttribute : ValidationAttribute
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
        if (((DateTime)value) > DateTime.Now)
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Time travel is not allowed");   
        } else {   
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }  
    }
}