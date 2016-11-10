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
    public class SpecialityController : Controller
    {
        private ISpecialityRepository repository;

        private EFDbContext db = new EFDbContext();

        public SpecialityController(ISpecialityRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Specialities.ToList());
        }

        public ViewResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                repository.Create(speciality);

                TempData["message"] = "Специальность успешно добавлена";

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", speciality.DepartmentId);
            return View(speciality);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            Speciality speciality = repository.Specialities.FirstOrDefault(_ => _.Id == id);

            if (speciality == null)
            {
                return View("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", speciality.DepartmentId);
            return View(speciality);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(speciality);

                TempData["message"] = "Информация о специальносте успешно редактирована";

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", speciality.DepartmentId);
            return View(speciality);
        }

        [HttpPost]
        public ActionResult Delete(Speciality speciality)
        {
            if (speciality == null)
            {
                return HttpNotFound();
            }

            speciality = db.Specialities.Find(speciality.Id);

            return View(speciality);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Speciality speciality)
        {
            repository.Delete(speciality.Id);

            TempData["message"] = "Специальность успешно удалена";

            return RedirectToAction("Index");
        }
    }
}