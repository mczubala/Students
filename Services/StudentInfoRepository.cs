using Microsoft.AspNetCore.Mvc;
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
    
    public async Task<bool> StudentExistsAsync(int cityId)
    {
        return await _context.Students.AnyAsync(c => c.Id == cityId);
    }
    public async Task<string> GetStudentLastNameAsync(int id)
    {
        var student = await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
        return student.LastName;
    }

    public Task CreateStudentAsync(Student newStudent)
    {
        _context.Students.Add(newStudent);
        return Task.CompletedTask;
    }

    public void DeleteStudent(Student student)
    {
        _context.Students.Remove(student);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}