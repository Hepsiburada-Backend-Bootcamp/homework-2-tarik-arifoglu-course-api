using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_Management_Api.Models;

namespace Course_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public CourseController(CourseDbContext context)
        {
            _context = context;
        }

        // Get courses
        [HttpGet]
        public IActionResult GetCourses()
        {
            return  Ok(_context.Courses.ToList());
        }

        // Get specified course
        [HttpGet("{id}")]
        public  IActionResult GetCourse(long id)
        {
            var course =  _context.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // Update specified course
        [HttpPut("{id}")]
        public  IActionResult PutCourse(long id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Create new course
        [HttpPost]
        public IActionResult PostCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // Delete specified course
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(long id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return NoContent();
        }

        private bool CourseExists(long id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
