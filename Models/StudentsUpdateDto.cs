using System.ComponentModel.DataAnnotations;

namespace Students.Models;

public class StudentsUpdateDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }
}