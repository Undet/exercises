using System.ComponentModel.DataAnnotations;

namespace exercises.Data.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}