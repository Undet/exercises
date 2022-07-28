using System.ComponentModel.DataAnnotations;

namespace exercises.Data.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripton { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
