using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.DataLayer
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolContext _context;
        public StudentRepository()
        {
            _context = new SchoolContext();

        }

        public IEnumerable<Student> GetStudents(Func<Student, bool> func =null)
        {
            if (func != null)
            {
                return _context.Students.Where(func);
            }

            return _context.Students;
        }

        
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }

     
    }
}