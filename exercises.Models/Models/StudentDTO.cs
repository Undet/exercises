using System.ComponentModel.DataAnnotations;

namespace exercises.Models
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public IEnumerable<CourseDTO> Courses { get; set; }

    }
}
