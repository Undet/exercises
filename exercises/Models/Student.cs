﻿using System.ComponentModel.DataAnnotations;

namespace exercises
{
    public class Student
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
