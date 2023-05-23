using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebAPI.Models;

namespace StudentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudent()
        {
            return await _studentDbContext.Students.ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            _studentDbContext.Students.Add(student);
            await _studentDbContext.SaveChangesAsync();
            return student;
            //return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

    }
}
