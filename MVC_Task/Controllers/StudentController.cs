using Microsoft.AspNetCore.Mvc;
using MVC_Task.Models;
using MVC_Task.Models.Entities;
using MVC_Task.Services;
using System.Threading;
using System.Globalization;

namespace MVC_Task.Controllers
{
    public class StudentController : BaseController
    {
        readonly IStudent  StudentRepo;
        readonly Pager Pager;

        public StudentController(IStudent _studentRepo,Pager pager)
        {
            StudentRepo = _studentRepo;
            Pager = pager;
        }

        public IActionResult Index( StudentSearch StudentSearch,int page=1)
        {
            List<Student> SelectedStudents;


            const int PageSize = 5;
            if (page < 1)
            {
                page = 1;
            }

            SelectedStudents = StudentRepo.SearchStudent(StudentSearch);

            ViewData["NameFilter"] = StudentSearch.Name;
            ViewData["CityFilter"] = StudentSearch.City;
            ViewData["GenderFilter"] = StudentSearch.Gender;
            ViewData["FromFilter"] = StudentSearch.From;
            ViewData["ToFilter"] = StudentSearch.To;

            int recSkip = (page - 1) * PageSize;
            ViewBag.Students = SelectedStudents.Skip(recSkip).Take(PageSize);
            Pager.setPager(SelectedStudents.Count(), page, PageSize);

            ViewBag.pager = Pager;

            return View();

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            StudentRepo.AddStudent(student);
            StudentRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id is null)
            {
                return BadRequest();
            }
            else
            {
                Student student = StudentRepo.GetStudentById(Id.Value);
                if (student is null)
                {
                    return NotFound();
                }
                else
                {
                    return View(student);
                }
            }
        }
        [HttpPost]
        public IActionResult Edit(Student Student, Boolean IsEnrolled)
        {
            if (!ModelState.IsValid) {
                return View(Student);            
            }
            Student.IsEnrolled = IsEnrolled;
            StudentRepo.UpdateStudent(Student);
            StudentRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id is null)
            {
                return BadRequest();
            }
            else
            {
                Student student = StudentRepo.GetStudentById(Id.Value);
                if (student is null)
                {
                    return NotFound();
                }
                else
                {
                    return View(student);
                }
            }
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? Id)
        {
            StudentRepo.DeleteStudent(Id.Value);
            StudentRepo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
