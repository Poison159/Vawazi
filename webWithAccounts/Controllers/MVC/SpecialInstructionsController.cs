﻿using System;
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
    public class SpecialInstructionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpecialInstructions
        public ActionResult Index()
        {
            return View(db.SpecialInstructions.ToList());
        }

        // GET: SpecialInstructions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialInstruction specialInstruction = db.SpecialInstructions.Find(id);
            if (specialInstruction == null)
            {
                return HttpNotFound();
            }
            return View(specialInstruction);
        }

        // GET: SpecialInstructions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialInstructions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,indawoId,instruction")] SpecialInstruction specialInstruction)
        {
            if (ModelState.IsValid)
            {
                db.SpecialInstructions.Add(specialInstruction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialInstruction);
        }

        // GET: SpecialInstructions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialInstruction specialInstruction = db.SpecialInstructions.Find(id);
            if (specialInstruction == null)
            {
                return HttpNotFound();
            }
            return View(specialInstruction);
        }

        // POST: SpecialInstructions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,indawoId,instruction")] SpecialInstruction specialInstruction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialInstruction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialInstruction);
        }

        // GET: SpecialInstructions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialInstruction specialInstruction = db.SpecialInstructions.Find(id);
            if (specialInstruction == null)
            {
                return HttpNotFound();
            }
            return View(specialInstruction);
        }

        // POST: SpecialInstructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialInstruction specialInstruction = db.SpecialInstructions.Find(id);
            db.SpecialInstructions.Remove(specialInstruction);
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
