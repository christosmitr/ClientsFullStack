using ClientsAPI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ClientsAPI.Models.DTO
{
    public class ClientDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "First name should contain only alphabetic characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Last name should contain only alphabetic characters.")]
        public string LastName { get; set; }


        [ValidatePhoneNumbers(ErrorMessage = "At least one phone number must be provided.")]
        public PhonesDTO Phones { get; set; }
        
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
