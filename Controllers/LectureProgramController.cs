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
    public class LectureProgramController : ControllerBase
    {
        private readonly CourseDbContext _context;

        // Context
        public LectureProgramController(CourseDbContext context)
        {
            _context = context;
        }

        // Get all lecture programs
        [HttpGet]
        public IActionResult GetLecturePrograms()
        {
            return Ok(_context.LecturePrograms.ToList());
        }

        // Get specified lecture program
        [HttpGet("{id}")]
        public IActionResult GetLectureProgram(long id)
        {
            var lectureProgram = _context.LecturePrograms.Find(id);

            if (lectureProgram == null)
            {
                return NotFound();
            }

            return Ok(lectureProgram);
        }

        // update specified lecture program
        [HttpPut("{id}")]
        public IActionResult PutLectureProgram(long id, LectureProgram lectureProgram)
        {
            if (id != lectureProgram.LectureProgramId)
            {
                return BadRequest();
            }

            _context.Entry(lectureProgram).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureProgramExists(id))
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

        // Create new lecture program
        [HttpPost]
        public IActionResult PostLectureProgram(LectureProgram lectureProgram)
        {
            _context.LecturePrograms.Add(lectureProgram);
            _context.SaveChanges();

            return CreatedAtAction("GetLectureProgram", new { id = lectureProgram.LectureProgramId }, lectureProgram);
        }

        // Delete specified lecture program
        [HttpDelete("{id}")]
        public IActionResult DeleteLectureProgram(long id)
        {
            var lectureProgram = _context.LecturePrograms.Find(id);
            if (lectureProgram == null)
            {
                return NotFound();
            }

            _context.LecturePrograms.Remove(lectureProgram);
            _context.SaveChanges();

            return NoContent();
        }

        private bool LectureProgramExists(long id)
        {
            return _context.LecturePrograms.Any(e => e.LectureProgramId == id);
        }
    }
}
