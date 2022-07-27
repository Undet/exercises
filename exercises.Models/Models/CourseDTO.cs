
using System.ComponentModel.DataAnnotations;

namespace exercises.Models
{
    public class CourseDTO
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripton { get; set; }
        [Required]
        public string Password { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }
    }
}
