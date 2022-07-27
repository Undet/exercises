using exercises.Models;
using System.ComponentModel.DataAnnotations;

namespace exercises.Respounses.Students
{
    public class GetStudentByIdResponseDTO
    {
        public string Name { get; set; }

        public string SecondName { get; set; }
        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
