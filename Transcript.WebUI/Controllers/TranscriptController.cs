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
    public class TranscriptController : Controller
    {
        private ITranscriptRepository repository;

        private EFDbContext db = new EFDbContext();

        public TranscriptController(ITranscriptRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Transcripts.ToList());
        }

        public ViewResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName");
            ViewBag.TypeControlId = new SelectList(db.TypesControl, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transcript.Domain.Entities.Transcript transcript)
        {
            if (ModelState.IsValid)
            {
                repository.Create(transcript);

                TempData["message"] = "Информация об успеваемости успешно добавлена";

                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName", transcript.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", transcript.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName", transcript.TeacherId);
            ViewBag.TypeControlId = new SelectList(db.TypesControl, "Id", "Name", transcript.TypeControlId);
            return View(transcript);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            Transcript.Domain.Entities.Transcript transcript = repository.Transcripts.FirstOrDefault(_ => _.Id == id);

            if (transcript == null)
            {
                return View("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName", transcript.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", transcript.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName", transcript.TeacherId);
            ViewBag.TypeControlId = new SelectList(db.TypesControl, "Id", "Name", transcript.TypeControlId);
            return View(transcript);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transcript.Domain.Entities.Transcript transcript)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(transcript);

                TempData["message"] = "Информация о успеваемости успешно редактирована";

                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName", transcript.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", transcript.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName", transcript.TeacherId);
            ViewBag.TypeControlId = new SelectList(db.TypesControl, "Id", "Name", transcript.TypeControlId);
            return View(transcript);
        }

        [HttpPost]
        public ActionResult Delete(Transcript.Domain.Entities.Transcript transcript)
        {
            if (transcript == null)
            {
                return HttpNotFound();
            }
            transcript = db.Transcripts.Find(transcript.Id);
            return View(transcript);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Transcript.Domain.Entities.Transcript transcript)
        {
            repository.Delete(transcript.Id);

            TempData["message"] = "Информация об успеваемости успешно удалена";

            return RedirectToAction("Index");
        }
    }
}