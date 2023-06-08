using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Task.Models.Entities
{
    public partial class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Gender field is required")]
        public string? Gender { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please enter a valid Name alphabets only")]
     
        public string? Name { get; set; }

        [Required(ErrorMessage = "The City field is required")]
        public string? City { get; set; }

        [Required(ErrorMessage = "The DateOfBirth field is required")]
        public DateTime? DateOfBirth { get; set; }
        public bool? IsEnrolled { get; set; }
    }
}
