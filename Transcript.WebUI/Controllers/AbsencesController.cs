using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Transcript.Domain.Context;
using Transcript.Domain.Entities;

namespace Transcript.WebUI.Controllers
{
    public class AbsencesController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Absences
        public ActionResult Index()
        {
            var absences = db.Absences.Include(a => a.Student).Include(a => a.Subject).Include(a => a.Teacher).Include(a => a.TypeClass);
            return View(absences.ToList());
        }

        // GET: Absences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.Absences.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        // GET: Absences/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName");
            ViewBag.TypeClassId = new SelectList(db.TypesClasses, "Id", "Name");
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,SubjectId,TeacherId,TypeClassId,DateAbsence")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                db.Absences.Add(absence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName", absence.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", absence.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName", absence.TeacherId);
            ViewBag.TypeClassId = new SelectList(db.TypesClasses, "Id", "Name", absence.TypeClassId);
            return View(absence);
        }

        // GET: Absences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.Absences.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName", absence.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", absence.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName", absence.TeacherId);
            ViewBag.TypeClassId = new SelectList(db.TypesClasses, "Id", "Name", absence.TypeClassId);
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,SubjectId,TeacherId,TypeClassId,DateAbsence")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(absence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "SecondName", absence.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", absence.SubjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "SecondName", absence.TeacherId);
            ViewBag.TypeClassId = new SelectList(db.TypesClasses, "Id", "Name", absence.TypeClassId);
            return View(absence);
        }

        // GET: Absences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.Absences.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Absence absence = db.Absences.Find(id);
            db.Absences.Remove(absence);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
