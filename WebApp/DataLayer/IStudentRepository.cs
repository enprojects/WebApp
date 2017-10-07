using System;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.DataLayer
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents(Func<Student, bool> func);
        void DeleteStudent(Student student);
        void AddStudent(Student student);
    }
}