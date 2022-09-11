using System.ComponentModel.DataAnnotations;

namespace exercises.Request.Students
{
    public class UpdateStudentRequestDTO
    {
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

    }
}
