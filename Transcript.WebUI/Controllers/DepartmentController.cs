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
    public class DepartmentController : Controller
    {
        private IDepartmentRepository repository;

        private EFDbContext db = new EFDbContext();

        public DepartmentController(IDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Departments.ToList());
        }

        public ViewResult Create()
        {
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                repository.Create(department);

                TempData["message"] = "Кафедра успешно добавлена";

                return RedirectToAction("Index");
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name", department.FacultyId);
            return View(department);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            Department department = repository.Departments.FirstOrDefault(_ => _.Id == id);

            if (department == null)
            {
                return View("Index");
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name", department.FacultyId);
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(department);

                TempData["message"] = "Информация о кафедре успешно редактирована";

                return RedirectToAction("Index");
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name", department.FacultyId);
            return View(department);
        }

        [HttpPost]
        public ViewResult Delete(Department department)
        {
            if (department == null)
            {
                return View("Index");
            }

            department = repository.Departments.FirstOrDefault(_ => _.Id == department.Id);

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Department department)
        {
            repository.Delete(department.Id);

            TempData["message"] = "Кафедра успешно удалена";

            return RedirectToAction("Index");
        }
    }
}