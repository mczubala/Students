using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.BLL;
using Students.Entities;
using Students.Models;
using Students.DAL.Repository;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentInfoRepository _studentInfoRepository;
        private StudentsBLL _studentsBLL;
        
        public StudentsController(IStudentInfoRepository studentInfoRepository, IMapper mapper)
        {
            _studentInfoRepository = studentInfoRepository?? throw new ArgumentNullException(nameof(studentInfoRepository));
            //przez interfejst
            _studentsBLL = new StudentsBLL(_studentInfoRepository, mapper);
        }
        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsDto>>> GetStudentsAsync()
        {
            // var studentsEtities = await _studentInfoRepository.GetStudentsAsync();
            // return Ok(_mapper.Map<IEnumerable<StudentsDto>>(studentsEtities));
            var abc = await _studentsBLL.GetStudentsAsync();
            return Ok(abc);
        }

        // // GET: api/Students/1
        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetStudent(int id)
        // {
        //     var student = await _studentsBLL.GetStudentAsync(id);
        //     if (student == null) return NotFound();
        //     return Ok(student);
        // }
        
        // GET: api/Students/1/lastname
        // [HttpGet("{id}/lastname")]
        // public async Task<ActionResult<string>> GetStudentLastNameAsync(int id)
        // {
        //     var student = await _studentInfoRepository.GetStudentLastNameAsync(id);
        //     if (student == null) return NotFound();
        //     return Ok(student);
        // }
        // // POST: api/Students
        // [HttpPost]
        // public async Task<ActionResult<StudentsDto>> CreateStudent([FromBody] StudentsCreateDto newStudent)
        // {
        //     await _studentInfoRepository.CreateStudentAsync(_mapper.Map<Entities.Student>(newStudent));
        //     await _studentInfoRepository.SaveChangesAsync();
        //     return Ok();
        // }
        //
        // // PUT: api/Students/1
        // [HttpPut("{id}")]
        // public async Task<ActionResult> UpdateStudent(int id, [FromBody] StudentsUpdateDto updateStudent)
        // {
        //     var studentEntity = await _studentInfoRepository.GetStudentAsync(id);
        //     _mapper.Map(updateStudent, studentEntity);
        //     await _studentInfoRepository.SaveChangesAsync();
        //
        //     return NoContent();
        //
        // }
        //
        // // DELETE: api/Students/1
        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteStudent(int id)
        // {
        //     if (!await _studentInfoRepository.StudentExistsAsync(id)) return NotFound();
        //     Student student = await _studentInfoRepository.GetStudentAsync(id);
        //     await _studentInfoRepository.DeleteStudent(student);
        //     await _studentInfoRepository.SaveChangesAsync();
        //
        //     return NoContent();
        // }
    }
}
