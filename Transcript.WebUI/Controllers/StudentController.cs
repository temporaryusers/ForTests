using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transcript.Domain.Context;
using Transcript.Domain.Entities;
using Transcript.Domain.Interfaces;

namespace Transcript.WebUI.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository repository;

        private EFDbContext db = new EFDbContext();

        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Students.ToList());
        }

        public ViewResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                repository.Create(student);

                TempData["message"] = "Студент успешно добавлен";

                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", student.GroupId);
            return View(student);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            Student student = repository.Students.FirstOrDefault(_ => _.Id == id);

            if (student == null)
            {
                return View("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", student.GroupId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(student);

                TempData["message"] = "Информация о студенте успешно редактирована";

                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "Name", student.GroupId);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            if (student == null)
            {
                return HttpNotFound();
            }
            student = db.Students.Find(student.Id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Student student)
        {
            repository.Delete(student.Id);

            TempData["message"] = "Студент успешно удален";

            return RedirectToAction("Index");
        }
    }
}