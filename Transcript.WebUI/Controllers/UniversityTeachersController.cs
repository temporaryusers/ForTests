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
    public class UniversityTeachersController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: UniversityTeachers
        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(u => u.Department).Include(u => u.Position);
            return View(teachers.ToList());
        }

        // GET: UniversityTeachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityTeacher universityTeacher = db.Teachers.Find(id);
            if (universityTeacher == null)
            {
                return HttpNotFound();
            }
            return View(universityTeacher);
        }

        // GET: UniversityTeachers/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name");
            return View();
        }

        // POST: UniversityTeachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SecondName,FirstName,MiddleName,DepartmentId,PositionId")] UniversityTeacher universityTeacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(universityTeacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", universityTeacher.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", universityTeacher.PositionId);
            return View(universityTeacher);
        }

        // GET: UniversityTeachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityTeacher universityTeacher = db.Teachers.Find(id);
            if (universityTeacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", universityTeacher.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", universityTeacher.PositionId);
            return View(universityTeacher);
        }

        // POST: UniversityTeachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SecondName,FirstName,MiddleName,DepartmentId,PositionId")] UniversityTeacher universityTeacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universityTeacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", universityTeacher.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", universityTeacher.PositionId);
            return View(universityTeacher);
        }

        // GET: UniversityTeachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityTeacher universityTeacher = db.Teachers.Find(id);
            if (universityTeacher == null)
            {
                return HttpNotFound();
            }
            return View(universityTeacher);
        }

        // POST: UniversityTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UniversityTeacher universityTeacher = db.Teachers.Find(id);
            db.Teachers.Remove(universityTeacher);
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
