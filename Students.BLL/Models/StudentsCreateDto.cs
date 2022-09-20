using System.ComponentModel.DataAnnotations;

namespace Students.Models
{
    public class StudentsCreateDto
    {
        [Required (ErrorMessage = "Provide First Name")]
        [MaxLength(40)]
        public string? FirstName { get; set; }
        [Required (ErrorMessage = "Provide Last Name")]
        [MaxLength(40)]
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
    }
}