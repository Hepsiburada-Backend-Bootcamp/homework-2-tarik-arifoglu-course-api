using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Course_Management_Api.Models
{
    public partial class Educator
    {
        public Educator()
        {
            LecturePrograms = new HashSet<LectureProgram>();
        }

        public long EducatorId { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 20 characters")]
        public string Name { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Surname should be between 2 and 20 characters")]
        public string Surname { get; set; }

        [RegularExpression("(M|W)", ErrorMessage = "Only M or W is allowed")]
        public string Gender { get; set; }

        public virtual ICollection<LectureProgram> LecturePrograms { get; set; }
    }
}
