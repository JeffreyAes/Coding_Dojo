using System.ComponentModel.DataAnnotations;
namespace DishesNChefs.Models;

public class ForeignKeyReqAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((int)value == 0)
        {
        System.Console.WriteLine(value is int);
            return new ValidationResult("musn't be null");
        }

        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if (_context.Chefs.All(c => c.ChefId != (int)value))
        {
            return new ValidationResult("ChefId doesn't exist!");
        }

        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}