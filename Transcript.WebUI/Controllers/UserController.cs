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
    public class UserController : Controller
    {
        private IUserRepository repository;

        private EFDbContext db = new EFDbContext();

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Users.ToList());
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                repository.Create(user);

                TempData["message"] = "Пользователь успешно добавлен";

                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Index");
            }
            User user = repository.Users.FirstOrDefault(_ => _.Id == id);

            if (user == null)
            {
                return View("Index");
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(user);

                TempData["message"] = "Информация о пользователе успешно редактирована";

                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(User user)
        {
            repository.Delete(user.Id);

            TempData["message"] = "Пользователь успешно удален";

            return RedirectToAction("Index");
        }
    }
}