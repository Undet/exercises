using exercises.Request.Students;
using exercises.Respounses.Students;
using System.ComponentModel.DataAnnotations;

namespace exercises.Models.Responses.Course
{
    public class CreateCourseResDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripton { get; set; }
        public IEnumerable<CreateStudentResponseDTO> Students { get; set; }
    }
}
