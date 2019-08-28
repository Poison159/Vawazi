using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webWithAccounts.Models;

namespace webWithAccounts.Controllers
{
    public class OperatingHoursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OperatingHours
        public ActionResult Index()
        {
            return View(db.OperatingHours.ToList());
        }

        // GET: OperatingHours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperatingHours operatingHours = db.OperatingHours.Find(id);
            if (operatingHours == null)
            {
                return HttpNotFound();
            }
            return View(operatingHours);
        }

        // GET: OperatingHours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OperatingHours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,indawoId,day,openingHour,closingHour")] OperatingHours operatingHours)
        {
            if (ModelState.IsValid)
            {
                if (operatingHours.closingHour.TimeOfDay.ToString().First() == '0') {
                    operatingHours.closingHour = operatingHours.closingHour.AddDays(1);
                }
                db.OperatingHours.Add(operatingHours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operatingHours);
        }

        // GET: OperatingHours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperatingHours operatingHours = db.OperatingHours.Find(id);
            if (operatingHours == null)
            {
                return HttpNotFound();
            }
            return View(operatingHours);
        }

        // POST: OperatingHours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,indawoId,day,openingHour,closingHour")] OperatingHours operatingHours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operatingHours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operatingHours);
        }

        // GET: OperatingHours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperatingHours operatingHours = db.OperatingHours.Find(id);
            if (operatingHours == null)
            {
                return HttpNotFound();
            }
            return View(operatingHours);
        }

        // POST: OperatingHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OperatingHours operatingHours = db.OperatingHours.Find(id);
            db.OperatingHours.Remove(operatingHours);
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
