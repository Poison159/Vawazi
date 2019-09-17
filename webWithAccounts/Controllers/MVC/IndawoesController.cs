using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webWithAccounts.Models;


namespace Ziwava.Controllers.mvc
{
    public class IndawoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Indawoes
        public ActionResult Index()
        {
            return View(db.Indawoes.ToList());
        }

        // GET: Indawoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indawo indawo = db.Indawoes.Find(id);
            if (indawo == null)
            {
                return HttpNotFound();
            }
            return View(indawo);
        }

        // GET: Indawoes/Create
        public ActionResult Create()
        {
            Indawo indawo = new Indawo();
            return View(indawo);
        }

        // POST: Indawoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,lat,lon,address,rating,type,imgPath,entranceFee,instaHandle,imageUpload")] Indawo indawo)
        {
            //Check images and Operating hours
            if (ModelState.IsValid)
            {
                db.Indawoes.Add(indawo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create", "Images", new { area = "" });
        }

        // GET: Indawoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indawo indawo = db.Indawoes.Find(id);
            if (indawo == null)
            {
                return HttpNotFound();
            }
            return View(indawo);
        }

        // POST: Indawoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,lat,lon,address,imgPath,instaHandle")] Indawo indawo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indawo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indawo);
        }

        // GET: Indawoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indawo indawo = db.Indawoes.Find(id);
            if (indawo == null)
            {
                return HttpNotFound();
            }
            return View(indawo);
        }

        // POST: Indawoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indawo indawo = db.Indawoes.Find(id);
            db.Indawoes.Remove(indawo);
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
