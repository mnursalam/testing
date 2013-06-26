﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTesting.Models;

namespace MvcTesting.Controllers
{
    public class MovieController : Controller
    {
        private ActDBContext db = new ActDBContext();

        //
        // GET: /Movie/

        public ActionResult Index()
        {
            return View(db.Movies.ToList());
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
            Console.WriteLine("create not ajax");
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
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
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

        //
        // POST: /Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Console.WriteLine("1==================================== ajax delete");
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

        public ActionResult ajax_page()
        {
            var list = db.Movies.ToList();
            return View(list);
        }

        public ActionResult ajax_list()
        {
            var list = db.Movies.ToList();
            return PartialView("ajax_list", list);
        }

        public ActionResult ajax_new_form(string data = "")
        {
            return PartialView("Page_form");
        }

        [HttpPost]
        public ActionResult ajax_create(Movie movie)
        {
            if (ModelState.IsValid)
            {                
                db.Movies.Add(movie);
                db.SaveChanges();
                return PartialView("ajax_list", db.Movies.ToList());
            }
            return PartialView("Page_form");
        }

        [HttpPost]
        public ActionResult ajax_update(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("ajax_list", db.Movies.ToList());
            }
            return PartialView("Page_form");
        }

        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        public ActionResult ajax_delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return PartialView("ajax_list", db.Movies.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}