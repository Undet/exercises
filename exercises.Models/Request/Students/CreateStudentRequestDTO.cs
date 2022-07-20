using System.ComponentModel.DataAnnotations;

namespace exercises.Request.Students
{
    public class CreateStudentRequestDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
