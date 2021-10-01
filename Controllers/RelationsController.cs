using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_Management_Api.Models;
using Course_Management_Api.Dto;
using AutoMapper;

namespace Course_Management_Api.Controllers
{
    [Route("api/relations")]
    [ApiController]
    public class RelationsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public RelationsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // Get the students which belongs to specified course
        [HttpGet("course_students")]
        public IActionResult GetCourseStudents(long courseId)
        {
            using (var dbConnection = new SqliteConnection("Data Source=SqliteDb/CourseDb.db;"))
            {
                var courseStudents = dbConnection.Query<Student>($"SELECT * FROM Students WHERE CourseId = {courseId};").ToList();
                List<StudentDto> dtoStudentList = new List<StudentDto>();
                //Mapping student list to student dto list
                foreach (Student student in courseStudents)
                {
                    dtoStudentList.Add(_mapper.Map<StudentDto>(student));
                }
                return Ok(dtoStudentList);
            }
        }

        // Get the specified educator's students
        [HttpGet("educator_students")]
        public IActionResult GetEducatorStudents(long educatorId)
        {
            using (var dbConnection = new SqliteConnection("Data Source=SqliteDb/CourseDb.db;"))
            {
                var courseStudents = dbConnection.Query<Student>(@$"SELECT DISTINCT st.StudentId,st.name,st.Surname FROM Students as st
                            INNER JOIN Courses as crs ON crs.CourseId=st.CourseId INNER JOIN Lectures as lcs ON lcs.CourseId=crs.CourseId INNER JOIN LecturePrograms lp
                            ON lp.LectureId=lcs.LectureId INNER JOIN Educators as edt ON lp.EducatorId=edt.EducatorId WHERE edt.EducatorId={educatorId}").ToList();
                List<StudentDto> dtoStudentList = new List<StudentDto>();
                //Mapping student list to student dto list
                foreach (Student student in courseStudents)
                {
                    dtoStudentList.Add(_mapper.Map<StudentDto>(student));
                }
                return Ok(dtoStudentList);
            }
        }
    }

}
