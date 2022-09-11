using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Controllers
{
    public class TeacherController : Controller
    {
        DbConnector _db = new DbConnector();
        public IActionResult Index()
        {
            var tecView = _db.teachers.ToList();
            return View(tecView);
        }
        public IActionResult CreateTeacher()
        {
            ViewBag.Heading = "Add Teacher";
            var viewModel = new TeacherViewModel();
            return View(viewModel);
        }

        public IActionResult SaveTeacher(TeacherViewModel viewModel)
        {
            var tec = new Teacher()
            {
                Name = viewModel.Name,
                Age = viewModel.Age,
                Subject = viewModel.Subject
            };
            _db.teachers.Add(tec);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Heading = "Edit Teacher";
            var tecEdit = _db.teachers.Single(x => x.Id == id);
            var element = new TeacherViewModel
            {
                Id = tecEdit.Id,
                
                Name = tecEdit.Name,
                Age = tecEdit.Age,
                Subject = tecEdit.Subject
                
            };
            return View("CreateTeacher", element);
        }

        public IActionResult UpdateTeacher(TeacherViewModel viewmodel)
        {
            var oldtec = _db.teachers.Single(x => x.Id == viewmodel.Id);
            oldtec.Name = viewmodel.Name;
            oldtec.Age = viewmodel.Age;
            oldtec.Subject = viewmodel.Subject;
            
            _db.SaveChanges();
            return RedirectToAction("Index", "Teacher");
        }

        public IActionResult Delete(int id)
        {
            var tecDelete = _db.teachers.Single(x => x.Id == id);
            _db.teachers.Remove(tecDelete);
            _db.SaveChanges();
            return RedirectToAction("Index", "Teacher");
        }
    }
}
