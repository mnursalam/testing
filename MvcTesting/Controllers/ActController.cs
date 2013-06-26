using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTesting.Models;

namespace MvcTesting.Controllers
{
    public class ActController : Controller
    {
        private ActDBContext db = new ActDBContext();

        //
        // GET: /Act/

        public ActionResult Index()
        {
            var acts = db.Acts.Include(c => c.Movies);
            return View(acts.ToList());
        }

        //
        // GET: /Act/Details/5

        public ActionResult Details(int id = 0)
        {            
            Act act = db.Acts.Find(id);
            if (act == null)
            {
                return HttpNotFound();
            }
            act = db.Acts.Include(c => c.Movies).
                Where(i => i.Id == id).First();
            return View(act);
        }

        //
        // GET: /Act/Create

        public ActionResult Create()
        {
            PopulateMoviesDropDownList2();
            PopulateStoreDropDownList();
            PopulateDropdownJenisKelamin();
            return View();
        }

        //
        // POST: /Act/Create

        [HttpPost]
        public ActionResult Create(Act act)
        {
            if (ModelState.IsValid)
            {
                db.Acts.Add(act);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            Create();
            return View(act);
        }

        //
        // GET: /Act/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Act act = db.Acts.Find(id);
            Console.WriteLine("1================================");
            PopulateMoviesDropDownList2(act.MovieID);
            PopulateStoreDropDownList(act.StoreID);
            PopulateDropdownJenisKelamin(act.JenisKelamin);
            if (act == null)
            {
                return HttpNotFound();
            }
            return View(act);
        }

        //
        // POST: /Act/Edit/5

        [HttpPost]
        public ActionResult Edit(Act act)
        {            
            if (ModelState.IsValid)
            {
                db.Entry(act).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(act);
        }

        //
        // GET: /Act/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Act act = db.Acts.Find(id);
            if (act == null)
            {
                return HttpNotFound();
            }
            return View(act);
        }

        //
        // POST: /Act/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Act act = db.Acts.Find(id);
            db.Acts.Remove(act);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateMoviesDropDownList(object selectedMovie = null)
        {
            var MoviesQuery = from d in db.Movies
                                   orderby d.Title
                                   select d;
            ViewBag.MovieID = new SelectList(MoviesQuery, "Id", "Title", selectedMovie);            
        }

        private void PopulateMoviesDropDownList2(object selectedMovie = null){         
            ViewBag.MovieID = new SelectList(db.Movies, "Id", "Title", selectedMovie);            
        }

        private void PopulateStoreDropDownList(object selectedStore = null){
            ViewBag.StoreID = new SelectList(db.Stores, "Id", "Name", selectedStore);
        }

        private void PopulateDropdownJenisKelamin(int jk = 0)
        {
            Console.WriteLine("s================================");
            ViewBag.JenisKelamin = new SelectList(new[]{
                                              new {ID="1",Name="Laki laki"},
                                              new {ID="2",Name="Perempuan"},},
                                               "ID", "Name", jk);
            ViewBag.JenisKelamin2 = new SelectList(new[]{
                                              new {ID="1",Name="Laki laki"},
                                              new {ID="2",Name="Waria"},
                                              new {ID="3",Name="Perempuan"},},
                                               "ID", "Name", jk);
            
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}