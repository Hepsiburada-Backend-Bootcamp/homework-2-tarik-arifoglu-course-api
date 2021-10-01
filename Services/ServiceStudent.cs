using Course_Management_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_Management_Api.Services
{
    public class ServiceStudent:IServiceStudent
    {
        private readonly CourseDbContext _context;

        public ServiceStudent(CourseDbContext context)
        {
            _context = context;
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public Student? GetStudent(long id)
        {
            return _context.Students.Find(id);
        }

        public bool PutStudent(long id, Student student)
        {
            if (id != student.StudentId)
            {
                return false;
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public void PostStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public bool DeleteStudent(long id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return true;
        }

        private bool StudentExists(long id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
