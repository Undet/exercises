using System.ComponentModel.DataAnnotations;

namespace exercises.DTO.Models
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
