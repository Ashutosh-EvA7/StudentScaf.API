using Microsoft.AspNetCore.Mvc;
using StudentScaf.Business.Interfaces;
using StudentScaf.Entity.Models;

namespace StudentScaf.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentScafController : ControllerBase
    {
        private readonly IStudentScafBusiness _studentScafBusiness;

        public StudentScafController(IStudentScafBusiness studentScafBusiness)
        {
            _studentScafBusiness = studentScafBusiness;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var students = _studentScafBusiness.GetList();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentScafBusiness.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Add(StudentScaff student)
        {
            _studentScafBusiness.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentScaff student)
        {
            _studentScafBusiness.Update(id, student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentScafBusiness.Delete(id);
            return NoContent();
        }
    }
}