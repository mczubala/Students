using Microsoft.EntityFrameworkCore;
using Students.DbContext;
using Students.Entities;
using Students.Models;

namespace Students.Services;

public class StudentInfoRepository: IStudentInfoRepository
{
    private readonly StudentsInfoContext _context;

    public StudentInfoRepository(StudentsInfoContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return await _context.Students.OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<Student?> GetStudentAsync(int id)
    {
        return await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
    public async Task<string> GetStudentLastNameAsync(int id)
    {
        var student = await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
        return student.LastName;
    }

    public Task CreateStudentAsync(StudentsCreateDto newStudent)
    {
        var student = new Student(newStudent.FirstName,newStudent.LastName);

        student.FirstName = newStudent.FirstName;
        student.LastName = newStudent.LastName;
        student.Age = newStudent.Age;
        student.Gender = newStudent.Gender;
            _context.Students.Add(student);
            return Task.CompletedTask;
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}