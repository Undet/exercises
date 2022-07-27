﻿using System.ComponentModel.DataAnnotations;

namespace exercises.Models.Responses.Course
{
    public class GetAllCoursesResDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripton { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }
    }
}
