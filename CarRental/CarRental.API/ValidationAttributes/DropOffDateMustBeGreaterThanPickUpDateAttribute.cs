using CarRental.API.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRental.API.ValidationAttributes
{
    public class DropOffDateMustBeGreaterThanPickUpDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var rental = (RentalForCreationDto)validationContext.ObjectInstance;

            if(rental.DropOffDate <= rental.PickUpDate)
            {
                return new ValidationResult(
                    ErrorMessage,
                    new[] { "RentalForCreationDto" });
            }

            return ValidationResult.Success;
        }
    }
}
