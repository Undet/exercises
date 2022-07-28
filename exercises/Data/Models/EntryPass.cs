using System.ComponentModel.DataAnnotations;

namespace exercises.Data.Models
{
    public class EntryPass
    {
        [Key]
        public int EntryPassId { get; set; }
        [Required]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public DateTime DateOfExpiry { get; set; }

        public EntryPass()
        {
            DateOfIssue = DateTime.Now;
            DateOfExpiry = DateTime.Now.Add(TimeSpan.FromDays(15));
        }

    }
}
