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
    public class GroupController : Controller
    {
        private IGroupRepository repository;

        private EFDbContext db = new EFDbContext();

        public GroupController(IGroupRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Groups.ToList());
        }

        public ViewResult Create()
        {
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "Name");
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupStudent group)
        {
            if (ModelState.IsValid)
            {
                repository.Create(group);

                TempData["message"] = "Группа успешно добавлена";

                return RedirectToAction("Index");
            }
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "Name", group.QualificationId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", group.SpecialityId);
            return View(group);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            GroupStudent group = repository.Groups.FirstOrDefault(_ => _.Id == id);

            if (group == null)
            {
                return View("Index");
            }
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "Name", group.QualificationId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", group.SpecialityId);
            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GroupStudent group)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(group);

                TempData["message"] = "Информация о группе успешно редактирована";

                return RedirectToAction("Index");
            }
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "Name", group.QualificationId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", group.SpecialityId);
            return View(group);
        }

        [HttpPost]
        public ActionResult Delete(GroupStudent group)
        {
            if (group == null)
            {
                return HttpNotFound();
            }

            group = db.Groups.Find(group.Id);

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(GroupStudent group)
        {
            repository.Delete(group.Id);

            TempData["message"] = "Группа успешно удалена";

            return RedirectToAction("Index");
        }
    }
}