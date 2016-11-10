using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Transcript.Domain.Context;
using Transcript.Domain.Entities;
using Transcript.Domain.Interfaces;

namespace Transcript.WebUI.Controllers
{
    public class AbsenceController : Controller
    {
        private IAbsenceRepository repository;

        private EFDbContext db = new EFDbContext();

        public AbsenceController(IAbsenceRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Absences.ToList());
        }

        public ViewResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName");
            ViewBag.StudentId2 = new SelectList(db.Students, "Id", "FirstName");
            ViewBag.StudentId3 = new SelectList(db.Students, "Id", "MiddleName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName");
            ViewBag.TypeClassId = new SelectList(db.TypesClasses, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Absence absence)
        {
            if (ModelState.IsValid)
            {
                repository.Create(absence);

                TempData["message"] = "Запись об отсутствии успешно добавлена";

                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName", absence.StudentId);
            ViewBag.StudentId2 = new SelectList(db.Students, "Id", "FirstName", absence.StudentId);
            ViewBag.StudentId3 = new SelectList(db.Students, "Id", "MiddleName", absence.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", absence.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName", absence.TeacherId);
            ViewBag.TypeClassId = new SelectList(db.TypesClasses, "Id", "Name", absence.TypeClassId);
            return View(absence);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            Absence absence = repository.Absences.FirstOrDefault(_ => _.Id == id);

            if (absence == null)
            {
                return View("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName", absence.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", absence.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName", absence.TeacherId);
            ViewBag.TypeClassId = new SelectList(db.TypesClasses, "Id", "Name", absence.TypeClassId);
            return View(absence);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Absence absence)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(absence);

                TempData["message"] = "Запись об отсутствии успешно редактирована";

                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName", absence.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", absence.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName", absence.TeacherId);
            ViewBag.TypeClassId = new SelectList(db.TypesClasses, "Id", "Name", absence.TypeClassId);
            return View(absence);
        }

        [HttpPost]
        public ViewResult Delete(Absence absence)
        {
            if (absence == null)
            {
                return View("Index");
            }
            absence = repository.Absences.FirstOrDefault(_ => _.Id == absence.Id);
            return View(absence);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Absence absence)
        {
            repository.Delete(absence.Id);

            TempData["message"] = "Запись об отсутствии успешно удалена";

            return RedirectToAction("Index");
        }
    }
}