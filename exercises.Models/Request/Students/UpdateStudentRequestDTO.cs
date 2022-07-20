using System.ComponentModel.DataAnnotations;

namespace exercises.Request.Students
{
    public class UpdateStudentRequestDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
