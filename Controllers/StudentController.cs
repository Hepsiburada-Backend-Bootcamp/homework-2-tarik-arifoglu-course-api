using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_Management_Api.Models;
using Course_Management_Api.Services;

namespace Course_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IServiceStudent _studentService;

        public StudentController(IServiceStudent studentService)
        {
            _studentService = studentService;
        }

        // Get all students
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_studentService.GetStudents());
        }

        // Get specified student
        [HttpGet("{id}")]
        public IActionResult GetStudent(long id)
        {
            var student= _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // Update specified student
        [HttpPut("{id}")]
        public IActionResult PutStudent(long id, Student student)
        {
            if(_studentService.PutStudent(id, student))
            {
                return NoContent();
            }
            return NotFound();

        }

        // Create new student
        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            _studentService.PostStudent(student);
            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }

        // Delete specified student
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            if (_studentService.DeleteStudent(id))
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}
