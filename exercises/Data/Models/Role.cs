using System.ComponentModel.DataAnnotations;

namespace exercises.Data.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }

        public virtual int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}