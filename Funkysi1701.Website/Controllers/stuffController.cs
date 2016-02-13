using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Funkysi1701.Website.Models;

namespace Funkysi1701.Website.Controllers
{
    public class stuffController : Controller
    {
        private stuffDBContext db = new stuffDBContext();

        // GET: stuffs
        public ActionResult Index()
        {
            return View(db.stuff.ToList());
        }

        // GET: stuffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stuff stuff = db.stuff.Find(id);
            if (stuff == null)
            {
                return HttpNotFound();
            }
            return View(stuff);
        }

        // GET: stuffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: stuffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text")] stuff stuff)
        {
            if (ModelState.IsValid)
            {
                db.stuff.Add(stuff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stuff);
        }

        // GET: stuffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stuff stuff = db.stuff.Find(id);
            if (stuff == null)
            {
                return HttpNotFound();
            }
            return View(stuff);
        }

        // POST: stuffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text")] stuff stuff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stuff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stuff);
        }

        // GET: stuffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stuff stuff = db.stuff.Find(id);
            if (stuff == null)
            {
                return HttpNotFound();
            }
            return View(stuff);
        }

        // POST: stuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stuff stuff = db.stuff.Find(id);
            db.stuff.Remove(stuff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
