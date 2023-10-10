using ClientsAPI.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace ClientsAPI.Attributes
{
    public class ValidatePhoneNumbersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phones = (PhonesDTO)value;

            if (phones != null && phones.IsAnyPhoneNumberProvided())
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
