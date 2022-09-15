using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Models;
using Students.Services;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentInfoRepository _studentInfoRepository;
        public StudentsController(IStudentInfoRepository studentInfoRepository)
        {
            _studentInfoRepository = studentInfoRepository?? throw new ArgumentNullException(nameof(studentInfoRepository));
        }
        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsDto>>> GetStudentsAsync()
        {
            var studentsEtities = await _studentInfoRepository.GetStudentsAsync();
            return Ok(studentsEtities);
        }

        // GET: api/Students/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var student = await _studentInfoRepository.GetStudentAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        
        // GET: api/Students/1/lastname
        [HttpGet("{id}/lastname")]
        public async Task<ActionResult<string>> GetStudentLastNameAsync(int id)
        {
            var student = await _studentInfoRepository.GetStudentLastNameAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<StudentsDto>> CreateStudent([FromBody] StudentsCreateDto newStudent)
        {
            await _studentInfoRepository.CreateStudentAsync(newStudent);
            return Ok();
        }
        //
        // // PUT: api/Students/1
        // [HttpPut("{id}")]
        // public ActionResult Put(int id, [FromBody] StudentsUpdateDto updateStudent)
        // {
        //     var student = _studentsDataStore.Students.FirstOrDefault(x => x.Id == id);
        //     if (student == null) return NotFound();
        //     if (updateStudent.FirstName != null) student.FirstName = updateStudent.FirstName;
        //     if (updateStudent.LastName != null) student.LastName = updateStudent.LastName;
        //     if (updateStudent.Age != null) student.Age = updateStudent.Age.GetValueOrDefault();
        //     if (updateStudent.Gender != null) student.Gender = updateStudent.Gender;
        //
        //     return NoContent();
        //
        // }
        //
        // // DELETE: api/Students/1
        // [HttpDelete("{id}")]
        // public ActionResult Delete(int id)
        // {
        //     var student = _studentsDataStore.Students.FirstOrDefault(x => x.Id == id);
        //     if (student == null) return NotFound();
        //     _studentsDataStore.Students.Remove(student);
        //     return NoContent();
        // }
    }
}
