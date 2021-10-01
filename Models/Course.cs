using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Course_Management_Api.Models
{
    public partial class Course
    {
        public Course()
        {
            Lectures = new HashSet<Lecture>();
            Students = new HashSet<Student>();
        }

        public long CourseId { get; set; }
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Course Name should be between 5 and 30 characters")]
        public string CourseName { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
