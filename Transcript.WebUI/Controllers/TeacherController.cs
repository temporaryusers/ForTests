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
    public class TeacherController : Controller
    {
        private ITeacherRepository repository;

        private EFDbContext db = new EFDbContext();

        public TeacherController(ITeacherRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Teachers.ToList());
        }

        public ViewResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UniversityTeacher teacher)
        {
            if (ModelState.IsValid)
            {
                repository.Create(teacher);

                TempData["message"] = "Преподаватель успешно добавлен";

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", teacher.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", teacher.PositionId);
            return View(teacher);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            UniversityTeacher teacher = repository.Teachers.FirstOrDefault(_ => _.Id == id);

            if (teacher == null)
            {
                return View("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", teacher.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", teacher.PositionId);
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UniversityTeacher teacher)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(teacher);

                TempData["message"] = "Информация о преподавателе успешно редактирована";

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", teacher.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", teacher.PositionId);
            return View(teacher);
        }

        [HttpPost]
        public ActionResult Delete(UniversityTeacher teacher)
        {
            if (teacher == null)
            {
                return HttpNotFound();
            }

            teacher = db.Teachers.Find(teacher.Id);

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(UniversityTeacher teacher)
        {
            repository.Delete(teacher.Id);

            TempData["message"] = "Преподаватель успешно удален";

            return RedirectToAction("Index");
        }
    }
}