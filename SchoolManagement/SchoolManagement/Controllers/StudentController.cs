using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;
using static System.Collections.Specialized.BitVector32;
using System.Security.Claims;
using System.Xml.Linq;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        DbConnector _db = new DbConnector();
        

        public IActionResult Index()
        {
            var stuView = _db.students.Include(r => r.Teacher).ToList();
            return View(stuView);
        }

        public IActionResult StudentCreate()
        {
            ViewBag.Heading = "Add a Student";
            var vm = new StudentViewModel()
            {
                teachers = _db.teachers
                
               
            };
            return View(vm);
            
        }
        
        public IActionResult SaveStudent(StudentViewModel svm)
        {

            
                var stu = new Student()
                {
                    Name = svm.Name,
                    Dob = svm.Dob,
                    Class = svm.Class,
                    Section = svm.Section,
                    TeacherId = svm.TeacherId
                };
                _db.students.Add(stu);
                _db.SaveChanges();
                return RedirectToAction("Index");

        }
      
        public IActionResult Edit(int id)
        {
            ViewBag.Heading = "Edit Student";
            var stuEdit = _db.students.Single(x => x.Id == id);
            var element = new StudentViewModel
            {
                Id = stuEdit.Id,
                teachers = _db.teachers.ToList(),
                Name = stuEdit.Name,
                Dob = stuEdit.Dob,
                Class = stuEdit.Class,
                Section = stuEdit.Section,
                TeacherId = stuEdit.TeacherId
            };
            return View("StudentCreate", element);
        }

        public IActionResult UpdateStudent(StudentViewModel viewmodel)
        {
            var oldstu = _db.students.Single(x => x.Id == viewmodel.Id);
            oldstu.Name = viewmodel.Name;
            oldstu.Dob = viewmodel.Dob;
            oldstu.Class = viewmodel.Class;
            oldstu.Section = viewmodel.Section;
            oldstu.TeacherId = viewmodel.TeacherId;
            _db.SaveChanges();
            return RedirectToAction("Index","Student"); 
        }

        public IActionResult Delete(int id)
        {
            var stuDelete = _db.students.Single(x => x.Id == id);
            _db.students.Remove(stuDelete);
            _db.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}
