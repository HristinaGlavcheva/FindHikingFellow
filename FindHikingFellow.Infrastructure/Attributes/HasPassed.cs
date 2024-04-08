using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Infrastructure.Attributes
{
    public class HasPassed : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if ((DateTime?)value >= DateTime.Now || (DateTime?)value <= DateTime.Now.AddYears(-20))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
