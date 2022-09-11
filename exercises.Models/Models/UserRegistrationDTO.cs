using System.ComponentModel.DataAnnotations;

namespace exercises.DTO.Models
{
    public class UserRegistrationDto
    {
        public string? Name { get; set; }
        public string? SecondName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

}
