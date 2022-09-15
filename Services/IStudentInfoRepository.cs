using Microsoft.AspNetCore.Mvc;
using Students.Entities;
using Students.Models;

namespace Students.Services;

public interface IStudentInfoRepository
{
    Task<IEnumerable<Student>> GetStudentsAsync();
    Task<Student?> GetStudentAsync(int id);
    Task<bool> StudentExistsAsync(int cityId);
    Task<string> GetStudentLastNameAsync(int id);
    Task CreateStudentAsync(Student newStudent);
    void DeleteStudent(Student student);

    Task<bool> SaveChangesAsync();
}