using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

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

        public EntryPass EntryPass { get; set; } = new EntryPass();
        public  IEnumerable<Course> Courses { get; set; } = new List<Course>();
        public virtual List<Role> Roles { get; set; } = new List<Role>();
        public string Role { get; set; } = String.Empty;
    }
}
