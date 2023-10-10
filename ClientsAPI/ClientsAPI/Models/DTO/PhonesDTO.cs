using ClientsAPI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ClientsAPI.Models.DTO
{
    public class PhonesDTO
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Homephone should contain only digits.")]
        public string? HomePhone { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Homephone should contain only digits.")]
        public string? WorkPhone { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Homephone should contain only digits.")]
        public string? MobilePhone { get; set; }

        
        public bool IsAnyPhoneNumberProvided()
        {
            return !string.IsNullOrWhiteSpace(HomePhone) || !string.IsNullOrWhiteSpace(WorkPhone) || !string.IsNullOrWhiteSpace(MobilePhone);
        }
    }
}
