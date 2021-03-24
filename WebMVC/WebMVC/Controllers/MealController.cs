using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class MealController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            var list = Crud().Select();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Meal meal)
        {
            if (ModelState.IsValid)
            {
                Crud().Insert(meal);
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        public ActionResult Edit(int id)
        {
            var meal = Crud().SelectById(id);
            return View(meal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Meal meal)
        {
            if (ModelState.IsValid)
            {
                Crud().Update(meal);
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        public ActionResult Details(int id)
        {
            var meal = Crud().SelectById(id);
            return View(meal);
        }

        public ActionResult Delete(int id)
        {
            var meal = Crud().SelectById(id);
            return View(meal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var meal = Crud().Delete(id);
            return RedirectToAction("Index");
        }

        public IMeal Crud()
        {
            return new MealDB();
        }
    }
}