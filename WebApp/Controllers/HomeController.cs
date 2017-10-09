using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.DataLayer;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetStudentsData()
        {
            var repository = new GeneralRepository<Student>(new SchoolContext());
            var students = repository.GetByCretiria();

            return Json(students, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult StudentUpdating(Student student)
        {
            var repository = new GeneralRepository<Student>(new SchoolContext());

            var current = repository.Get(x => x.StudentId == student.StudentId);

            if (current != null)
            {
                current.StudentLastName = student.StudentLastName;
                current.StudentName = student.StudentName;
                current.PhoneNumber = student.PhoneNumber;
            }

            var result = repository.Update();


            return Json(new { Success = result > 0 });
        }

        [HttpPost]
        public JsonResult StudentDeletion(Student student)
        {
            var repository = new GeneralRepository<Student>(new SchoolContext());
            var studentForDeletion = repository.Get(x => x.StudentId == student.StudentId);
            
            var result = repository.Delete(studentForDeletion);

            return Json(new { Success = result > 0 });
        }


        [HttpPost]
        public JsonResult StudentAdding(Student student)
        {
            var repository = new GeneralRepository<Student>(new SchoolContext());
            var result = repository.Add(student);

            return Json(new { Success = result > 0 });
        }
    }
}