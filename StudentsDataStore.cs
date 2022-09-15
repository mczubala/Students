using Students.Models;

namespace Students;

public class StudentsDataStore
{
    public List<StudentsDto> Students { get; set; }

    public StudentsDataStore()
    {
        Students = new List<StudentsDto>()
        {
            new StudentsDto()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Adamowicz",
                Age = 22,
                Gender = "male"
            },
            new StudentsDto()
            {
                Id = 2,
                FirstName = "Basia",
                LastName = "Basiowicz",
                Age = 33,
                Gender = "female"
            }
        };
    }
}