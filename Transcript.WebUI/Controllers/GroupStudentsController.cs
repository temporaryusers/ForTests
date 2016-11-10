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
    public class GroupStudentsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: GroupStudents
        public ActionResult Index()
        {
            var groups = db.Groups.Include(g => g.Qualification).Include(g => g.Speciality);
            return View(groups.ToList());
        }

        // GET: GroupStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStudent groupStudent = db.Groups.Find(id);
            if (groupStudent == null)
            {
                return HttpNotFound();
            }
            return View(groupStudent);
        }

        // GET: GroupStudents/Create
        public ActionResult Create()
        {
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "Name");
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name");
            return View();
        }

        // POST: GroupStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SpecialityId,QualificationId,Course")] GroupStudent groupStudent)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(groupStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "Name", groupStudent.QualificationId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", groupStudent.SpecialityId);
            return View(groupStudent);
        }

        // GET: GroupStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStudent groupStudent = db.Groups.Find(id);
            if (groupStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "Name", groupStudent.QualificationId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", groupStudent.SpecialityId);
            return View(groupStudent);
        }

        // POST: GroupStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SpecialityId,QualificationId,Course")] GroupStudent groupStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "Name", groupStudent.QualificationId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", groupStudent.SpecialityId);
            return View(groupStudent);
        }

        // GET: GroupStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStudent groupStudent = db.Groups.Find(id);
            if (groupStudent == null)
            {
                return HttpNotFound();
            }
            return View(groupStudent);
        }

        // POST: GroupStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupStudent groupStudent = db.Groups.Find(id);
            db.Groups.Remove(groupStudent);
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
