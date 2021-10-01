using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_Management_Api.Models;
using Course_Management_Api.Dto;
using AutoMapper;

namespace Course_Management_Api.Mapping
{
    public class MappingProfile:Profile
    {
        // Specify the objects to automap 
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Course, CourseDto>();
            CreateMap<Lecture, LectureDto>();
            CreateMap<Educator, EducatorDto>();
        }
    }
}
