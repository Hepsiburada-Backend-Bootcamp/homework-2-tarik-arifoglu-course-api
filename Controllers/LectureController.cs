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
    public class LectureController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public LectureController(CourseDbContext context)
        {
            _context = context;
        }

        // Get all lectures
        [HttpGet]
        public IActionResult GetLectures()
        {
            return Ok(_context.Lectures.ToList());
        }

        // Get specified lecture
        [HttpGet("{id}")]
        public IActionResult GetLecture(long id)
        {
            var lecture =  _context.Lectures.Find(id);

            if (lecture == null)
            {
                return NotFound();
            }

            return Ok(lecture);
        }

        // Update specified lecture
        [HttpPut("{id}")]
        public IActionResult PutLecture(long id, Lecture lecture)
        {
            if (id != lecture.LectureId)
            {
                return BadRequest();
            }

            _context.Entry(lecture).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureExists(id))
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

        // Create new lecture
        [HttpPost]
        public IActionResult PostLecture(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            _context.SaveChanges();

            return CreatedAtAction("GetLecture", new { id = lecture.LectureId }, lecture);
        }

        // Delete specified lecture
        [HttpDelete("{id}")]
        public IActionResult DeleteLecture(long id)
        {
            var lecture = _context.Lectures.Find(id);
            if (lecture == null)
            {
                return NotFound();
            }

            _context.Lectures.Remove(lecture);
            _context.SaveChanges();

            return NoContent();
        }

        private bool LectureExists(long id)
        {
            return _context.Lectures.Any(e => e.LectureId == id);
        }
    }
}
