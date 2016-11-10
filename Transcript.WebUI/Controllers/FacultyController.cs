using System.Linq;
using System.Net;
using System.Web.Mvc;
using Transcript.Domain.Entities;
using Transcript.Domain.Interfaces;

namespace Transcript.WebUI.Controllers
{
    public class FacultyController : Controller
    {
        private IFacultyRepository repository;

        public FacultyController(IFacultyRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Faculties.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                repository.Create(faculty);

                TempData["message"] = "Факультет успешно добавлен";

                return RedirectToAction("Index");
            }

            return View(faculty);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            Faculty faculty = repository.Faculties.FirstOrDefault(_ => _.Id == id);

            if (faculty == null)
            {
                return View("Index");
            }

            return View(faculty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(faculty);

                TempData["message"] = "Факультет успешно редактирован";
                
                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        [HttpPost]
        public ActionResult Delete(Faculty faculty)
        {
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Faculty faculty)
        {
            repository.Delete(faculty.Id);

            TempData["message"] = "Факультет успешно удален";
            
            return RedirectToAction("Index");
        }
    }
}