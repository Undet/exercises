using System.ComponentModel.DataAnnotations;

namespace exercises.Models
{
    public class UniversityDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public IEnumerable<StudentDTO> Students { get; set; }

    }
}
