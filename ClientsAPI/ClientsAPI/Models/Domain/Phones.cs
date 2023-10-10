using System.ComponentModel.DataAnnotations;

namespace ClientsAPI.Models.Domain
{
    public class Phones
    {
        public Guid Id { get; set; }

        [MaxLength(25)]
        public string? HomePhone { get; set; }
        [MaxLength(25)]
        public string? WorkPhone { get; set; }
        [MaxLength(25)]
        public string? MobilePhone { get; set; }
    }
}
