using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTesting.Models;
using PagedList;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using System.Web.Security;

namespace MvcTesting.Controllers
{
    public class MovieController : Controller
    {
        private BusinessLogic db = new BusinessLogic();

        //
        // GET: /Movie/

        public ActionResult Index(int? page)
        {            
            return View(db.getPaginateListMovies(page));
        }

        //
        // GET: /Movie/Details/5

        public ActionResult Details(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movie/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        //
        // GET: /Movie/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.update_data(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //
        // GET: /Movie/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult multiple_list()
        {
            return View();
        }

        public ActionResult partial_movies(int? page)
        {            
            return PartialView("partial_movies", db.getPaginateListMovies(page));
        }

        public ActionResult partial_acts()
        {
            return PartialView("partial_acts", db.Acts.ToList());
        }

        //
        // POST: /Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Aboutme(String data = "pisan euy")
        {
            var msg = "Dan Rea cantik, " + data.ToString();
            Console.WriteLine(msg);
            ViewBag.Message = msg;
            return View();
        }

        public ActionResult Aboutyou(int id=0)
        {
            var msg = "Dan Nungky, " + id.ToString();
            ViewBag.Message = msg;
            return View();
        }

        public ActionResult ajax_page(int? page)
        {            
            return View(db.getPaginateListMovies(page));
        }

        public ActionResult ajax_list(int? page)
        {        
            return PartialView("ajax_list", db.getPaginateListMovies(page));
        }

        public ActionResult ajax_new_form(string data = "")
        {
            return PartialView("Page_form");
        }

        public ActionResult ajax_detail(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("ajax_detail", movie);
        }

        public ActionResult ajax_edit(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("ajax_edit", movie);
        }

        [HttpPost]
        public ActionResult ajax_create(Movie _movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(_movie);
                db.SaveChanges();
                return PartialView("ajax_list", db.getPaginateListMovies());
            }
            return PartialView("Page_form", _movie);
        }

        [HttpPost]
        public ActionResult ajax_update(Movie movie)
        {
            if (ModelState.IsValid)
            {
                Movie movieToUpdate = db.Movies.Where(p => p.Id == movie.Id).FirstOrDefault();
                if (movieToUpdate != null)
                {
                    db.Entry(movieToUpdate).CurrentValues.SetValues(movie);
                }
                db.SaveChanges();
                return PartialView("ajax_list", db.Movies.ToList());
            }
            return PartialView("ajax_edit", movie);
        }

        [HttpPost]
        public ActionResult ajax_update2(Movie _movie)
        {
            if (ModelState.IsValid)
            {
                db.update_data(_movie);
                return PartialView("ajax_list", db.getPaginateListMovies());
            }
            return PartialView("ajax_edit", _movie);
        }
        
        [HttpPost]
        public ActionResult ajax_delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return PartialView("ajax_list", db.getPaginateListMovies());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }    
    
}