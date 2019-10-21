using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webWithAccounts.Models;

namespace webWithAccounts.Controllers.MVC
{
    public class ArtistEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArtistEvents
        public ActionResult Index()
        {
            return View(db.ArtistEvents.ToList());
        }

        // GET: ArtistEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistEvent artistEvent = db.ArtistEvents.Find(id);
            if (artistEvent == null)
            {
                return HttpNotFound();
            }
            return View(artistEvent);
        }

        // GET: ArtistEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,artistId,eventId")] ArtistEvent artistEvent)
        {
            if (ModelState.IsValid)
            {
                db.ArtistEvents.Add(artistEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artistEvent);
        }

        // GET: ArtistEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistEvent artistEvent = db.ArtistEvents.Find(id);
            if (artistEvent == null)
            {
                return HttpNotFound();
            }
            return View(artistEvent);
        }

        // POST: ArtistEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,artistId,eventId")] ArtistEvent artistEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artistEvent);
        }

        // GET: ArtistEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistEvent artistEvent = db.ArtistEvents.Find(id);
            if (artistEvent == null)
            {
                return HttpNotFound();
            }
            return View(artistEvent);
        }

        // POST: ArtistEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistEvent artistEvent = db.ArtistEvents.Find(id);
            db.ArtistEvents.Remove(artistEvent);
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
