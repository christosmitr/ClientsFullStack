using System.ComponentModel.DataAnnotations;

namespace ClientsAPI.Models.Domain
{
    public class Client
    {
        public Guid Id {get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        public Phones Phones { get; set; }
        [MaxLength(60)]
        public string Address { get; set; }
        [MaxLength(25)]
        public string Email { get; set; }
    }
}
