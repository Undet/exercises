using System.ComponentModel.DataAnnotations;

namespace exercises.Models
{
    public class EntryPassDTO
    {
        [Required]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public DateTime DateOfExpiry { get; set; }

    }
}
