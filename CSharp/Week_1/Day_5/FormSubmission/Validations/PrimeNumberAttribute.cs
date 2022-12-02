using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models;

public class PrimeNumber : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            Console.WriteLine("THE VALUE IS NULLLLLLLLLL");
            return new ValidationResult("Favorite prime number is required.");
        }
        int count = 0;
        int number = (int)value;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                count++;
            }
        }
        if (count == 2)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult($"{value} is not a prime number.");
    }
}