using exercises.Models;

namespace exercises.Respounses.Students
{
    public class UpdateStudentResponseDTO
    {
        public string Name { get; set; }
        public string SecondName { get; set; }

        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
