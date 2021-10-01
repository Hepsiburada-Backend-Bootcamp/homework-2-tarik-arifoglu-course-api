using System;
using System.Collections.Generic;

#nullable disable

namespace Course_Management_Api.Models
{
    public partial class LectureProgram
    {
        public long LectureProgramId { get; set; }
        public long LectureId { get; set; }
        public long EducatorId { get; set; }

        public virtual Educator Educator { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}
