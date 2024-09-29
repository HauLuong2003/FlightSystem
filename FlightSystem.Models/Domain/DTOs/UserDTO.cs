using System.ComponentModel.DataAnnotations;

namespace FlightSystem.Models.Domain.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set;}

    }
}
