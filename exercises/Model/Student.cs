using exercises.Model;
using System.ComponentModel.DataAnnotations;

namespace exercises
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
            this.EntryPass = new EntryPass();
            this.Courses = new List<Course>();
        }

    }
}
