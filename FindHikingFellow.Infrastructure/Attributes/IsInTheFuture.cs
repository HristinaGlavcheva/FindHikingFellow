using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Attributes
{
    public class IsInTheFuture : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if((DateTime?)value <= DateTime.Now)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
