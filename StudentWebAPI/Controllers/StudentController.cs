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

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(Student student)
        {
            _studentDbContext.Entry(student).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return student;
        }

        //[HttpPatch]
        //[Route("UpdateStudent/{id}")]
        //public async Task<ActionResult<Student>> UpdateStudent(int id)
        //{
        //    var student = await _studentDbContext.Students.FindAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    _studentDbContext.Students.Update(student);
        //    await _studentDbContext.SaveChangesAsync();
        //    return student;
        //}

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _studentDbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _studentDbContext.Students.Remove(student);
            await _studentDbContext.SaveChangesAsync();
            return student;
        }




    }
}
