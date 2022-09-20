using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Students.DAL;
using Students.Entities;
using Students.Models;
using Students.DAL.Repository;
using Students.DbContext;

namespace Students.BLL;

public class StudentsBLL
{
    private readonly IStudentInfoRepository _studentInfoRepository;
    private readonly IMapper _mapper;
    public StudentsBLL(IStudentInfoRepository studentInfoRepository, IMapper mapper)
    {
        _studentInfoRepository = studentInfoRepository?? throw new ArgumentNullException(nameof(studentInfoRepository));
        _mapper = mapper;
    }
    public async Task<IEnumerable<StudentsDto>> GetStudentsAsync()
    {
        var studentsEtities = await _studentInfoRepository.GetStudentsAsync();
        return _mapper.Map<IEnumerable<StudentsDto>>(studentsEtities);
    }
    
    public async Task<Student> GetStudentAsync(int id)
    {
        var student = await _studentInfoRepository.GetStudentAsync(id);
        return student;
        //return _mapper.Map<StudentsDto>(student);
    }
    public async Task<bool> StudentExistsAsync(int cityId)
    {
        return await _studentInfoRepository.StudentExistsAsync(cityId);
    }
    public async Task<string> GetStudentLastNameAsync(int id)
    {
        return await _studentInfoRepository.GetStudentLastNameAsync(id);
    }
    public async Task CreateStudentAsync(Student newStudent)
    {
        await _studentInfoRepository.CreateStudentAsync(_mapper.Map<Entities.Student>(newStudent));
        await _studentInfoRepository.SaveChangesAsync();
    }
    public async Task DeleteStudentAsync(int id)
    {
        Student student = await _studentInfoRepository.GetStudentAsync(id);
        await _studentInfoRepository.DeleteStudentAsync(student);
        
    }
    public async Task UpdateStudentAsync(int id, Student updateStudent)
    {
        var studentEntity = await _studentInfoRepository.GetStudentAsync(id);
        _mapper.Map(updateStudent, studentEntity);
        await _studentInfoRepository.SaveChangesAsync();
    }
    public async Task<bool> SaveChangesAsync()
    {
        return (await _studentInfoRepository.SaveChangesAsync());
    }
}