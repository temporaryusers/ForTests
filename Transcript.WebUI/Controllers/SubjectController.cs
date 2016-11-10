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
    public class SubjectController : Controller
    {
        private ISubjectRepository repository;

        private EFDbContext db = new EFDbContext();

        public SubjectController(ISubjectRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Subjects.ToList());
        }

        public ViewResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                repository.Create(subject);

                TempData["message"] = "Дисциплина успешно добавлена";

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", subject.DepartmentId);
            return View(subject);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            Subject subject = repository.Subjects.FirstOrDefault(_ => _.Id == id);

            if (subject == null)
            {
                return View("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", subject.DepartmentId);
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(subject);

                TempData["message"] = "Информация о дисциплине успешно редактирована";

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", subject.DepartmentId);
            return View(subject);
        }

        [HttpPost]
        public ActionResult Delete(Subject subject)
        {
            if (subject == null)
            {
                return HttpNotFound();
            }
            subject = db.Subjects.Find(subject.Id);
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Subject subject)
        {
            repository.Delete(subject.Id);

            TempData["message"] = "Дисциплина успешно удалена";

            return RedirectToAction("Index");
        }
    }
}