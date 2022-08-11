using exercises.Models;
using System.ComponentModel.DataAnnotations;

namespace exercises.Respounses.Students
{
    public class GetStudentByIdResponseDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Role { get; set; }

        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
