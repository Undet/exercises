using System.ComponentModel.DataAnnotations;

namespace exercises.Models.Request.Course
{
    public class CreateCourseRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripton { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }
    }
}
