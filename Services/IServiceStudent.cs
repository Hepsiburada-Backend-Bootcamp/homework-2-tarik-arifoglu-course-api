using Course_Management_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_Management_Api.Services
{
    public interface IServiceStudent
    {
        List<Student> GetStudents();
        Student? GetStudent(long id);
        bool PutStudent(long id, Student student);
        void PostStudent(Student student);
        bool DeleteStudent(long id);

    }
}
