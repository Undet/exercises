using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace exercises.Data.Models
{
    public class Student : IdentityUser
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

        public EntryPass EntryPass { get; set; } = new EntryPass();
        public  IEnumerable<Course> Courses { get; set; } = new List<Course>();
    }
}
