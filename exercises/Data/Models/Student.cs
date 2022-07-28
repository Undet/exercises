using System.ComponentModel.DataAnnotations;

namespace exercises.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Password { get; set; }

        public EntryPass EntryPass { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public Student()
        {
            EntryPass = new EntryPass();
            Courses = new List<Course>();
        }

    }
}
