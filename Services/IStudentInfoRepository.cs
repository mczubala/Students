using Students.Entities;
using Students.Models;

namespace Students.Services;

public interface IStudentInfoRepository
{
    Task<IEnumerable<Student>> GetStudentsAsync();
    Task<Student?> GetStudentAsync(int id);
    Task<string> GetStudentLastNameAsync(int id);
    Task CreateStudentAsync(StudentsCreateDto newStudent);
    Task<bool> SaveChangesAsync();
}