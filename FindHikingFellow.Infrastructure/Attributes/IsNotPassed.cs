using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Attributes
{
    public class IsNotPassed : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if((DateTime)value < DateTime.UtcNow)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
