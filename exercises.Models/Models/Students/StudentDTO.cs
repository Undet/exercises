using System.ComponentModel.DataAnnotations;

namespace exercises.Models.Students
{
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }
    }
}
