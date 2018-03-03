using System.ComponentModel.DataAnnotations;

namespace Hackathon.Accounts.Models
{
    public class RegistrationModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Country { get; set; }
        public string Gender { get; set; }
    }
}