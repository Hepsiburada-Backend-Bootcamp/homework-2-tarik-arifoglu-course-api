using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Course_Management_Api.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            LecturePrograms = new HashSet<LectureProgram>();
        }

        public long LectureId { get; set; }
        public long CourseId { get; set; }
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Lecture Code should be 5 characters long")]
        public string LectureCode { get; set; }
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Lecture Name should be between 5 and 30 characters")]
        public string LectureName { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<LectureProgram> LecturePrograms { get; set; }
    }
}
