using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RideShare.DAL;
using RideShare.Models;

namespace RideShare.Controllers
{
    public class ProfileController : Controller
    {
        private RideShareContext db = new RideShareContext();

        // GET: Profile
        public ActionResult Index()
        {
            return View(db.Postings.ToList());
        }

        // GET: Profile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostingModel postingModel = db.Postings.Find(id);
            if (postingModel == null)
            {
                return HttpNotFound();
            }
            return View(postingModel);
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PostingType,Name,Departure,Arrival,Date")] PostingModel postingModel)
        {
            if (ModelState.IsValid)
            {
                db.Postings.Add(postingModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postingModel);
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostingModel postingModel = db.Postings.Find(id);
            if (postingModel == null)
            {
                return HttpNotFound();
            }
            return View(postingModel);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PostingType,Name,Departure,Arrival,Date")] PostingModel postingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postingModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postingModel);
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostingModel postingModel = db.Postings.Find(id);
            if (postingModel == null)
            {
                return HttpNotFound();
            }
            return View(postingModel);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostingModel postingModel = db.Postings.Find(id);
            db.Postings.Remove(postingModel);
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
