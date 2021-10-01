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
    public class EducatorController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public EducatorController(CourseDbContext context)
        {
            _context = context;
        }

        // Get the educators
        [HttpGet]
        public IActionResult GetEducators()
        {
            return Ok(_context.Educators.ToList());
        }

        // Get specified educator
        [HttpGet("{id}")]
        public IActionResult GetEducator(long id)
        {
            var educator = _context.Educators.Find(id);

            if (educator == null)
            {
                return NotFound();
            }

            return Ok(educator);
        }

        // Update specified educator
        [HttpPut("{id}")]
        public IActionResult PutEducator(long id, Educator educator)
        {
            if (id != educator.EducatorId)
            {
                return BadRequest();
            }

            _context.Entry(educator).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducatorExists(id))
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

        // Add new educator
        [HttpPost]
        public IActionResult PostEducator(Educator educator)
        {
            _context.Educators.Add(educator);
            _context.SaveChanges();

            return CreatedAtAction("GetEducator", new { id = educator.EducatorId }, educator);
        }

        // Delete selected educator
        [HttpDelete("{id}")]
        public IActionResult DeleteEducator(long id)
        {
            var educator =  _context.Educators.Find(id);
            if (educator == null)
            {
                return NotFound();
            }

            _context.Educators.Remove(educator);
            _context.SaveChanges();

            return NoContent();
        }

        private bool EducatorExists(long id)
        {
            return _context.Educators.Any(e => e.EducatorId == id);
        }
    }
}
