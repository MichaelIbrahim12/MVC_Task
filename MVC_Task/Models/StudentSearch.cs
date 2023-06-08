using System.ComponentModel.DataAnnotations;

namespace MVC_Task.Models
{
    public class StudentSearch
    {

        public string? Name { get; set; }
        public string? Gender { get; set; }

        public string? City { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
