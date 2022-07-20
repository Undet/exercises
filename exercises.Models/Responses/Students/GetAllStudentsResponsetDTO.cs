using System.ComponentModel.DataAnnotations;

namespace exercises.Respounses.Students
{
    public class GetAllStudentsResponsetDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }
    }
}
