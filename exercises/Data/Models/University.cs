using System.ComponentModel.DataAnnotations;

namespace exercises.Data.Models
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public IEnumerable<Student> Students { get; set; }

    }
}
