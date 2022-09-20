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
    
    // public async Task<Student> GetStudentAsync(int id)
    // {
    //     var student = await _studentInfoRepository.GetStudentAsync(id);
    //     return student;
    // }
}