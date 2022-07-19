using System.ComponentModel.DataAnnotations;

namespace exercises
{
    public class Student
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(2-36)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2 - 36)]
        public string SecondName { get; set; }
    }
}
