using JoelHiltonFilm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilm.Controllers
{
    public class HomeController : Controller
    {
        private FilmContext FilmCont { get; set; }

        public HomeController(FilmContext x)
        {
            FilmCont = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = FilmCont.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(FormResponse ar)
        {
            if (ModelState.IsValid)
            {
                FilmCont.Add(ar);
                FilmCont.SaveChanges();

                return RedirectToAction("FilmList");
            }
            else
            {
                ViewBag.Categories = FilmCont.Categories.ToList();

                return View();
            }
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilmList ()
        {
            var applications = FilmCont.responses
                .Include(x => x.Category)
                .ToList();
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit (int applicationid)
        {
            ViewBag.Categories = FilmCont.Categories.ToList();

            var application = FilmCont.responses.Single(x => x.ApplicationId == applicationid);

            return View("AddMovie", application);
        }

        [HttpPost]
        public IActionResult Edit (FormResponse fr)
        {
            FilmCont.Update(fr);
            FilmCont.SaveChanges();

            return RedirectToAction("FilmList");
        }

        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var application = FilmCont.responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(FormResponse fr)
        {
            FilmCont.responses.Remove(fr);
            FilmCont.SaveChanges();

            return RedirectToAction("FilmList");
        }
    }
}
