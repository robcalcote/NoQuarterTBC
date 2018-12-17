using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoQuarterTBC.DAL;
using NoQuarterTBC.Models;

namespace NoQuarterTBC.Controllers.Admin
{
    public class EncountersController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Encounters
        public ActionResult Index()
        {
            var encounter = db.Encounter.Include(e => e.bosses);
            return View("~/Views/Admin/Encounters/Index.cshtml", encounter.ToList());
        }

        // GET: Encounters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encounter encounter = db.Encounter.Find(id);
            if (encounter == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Encounters/Details.cshtml", encounter);
        }

        // GET: Encounters/Create
        public ActionResult Create()
        {
            ViewBag.BossID = new SelectList(db.Bosses, "BossID", "BossName");
            return View("~/Views/Admin/Encounters/Create.cshtml");
        }

        // POST: Encounters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EncounterID,BossID,BossFirstKill,BossKillTime")] Encounter encounter)
        {
            if (ModelState.IsValid)
            {
                db.Encounter.Add(encounter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BossID = new SelectList(db.Bosses, "BossID", "BossName", encounter.BossID);
            return View("~/Views/Admin/Encounters/Create.cshtml", encounter);
        }

        // GET: Encounters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encounter encounter = db.Encounter.Find(id);
            if (encounter == null)
            {
                return HttpNotFound();
            }
            ViewBag.BossID = new SelectList(db.Bosses, "BossID", "BossName", encounter.BossID);
            return View("~/Views/Admin/Encounters/Edit.cshtml", encounter);
        }

        // POST: Encounters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EncounterID,BossID,BossFirstKill,BossKillTime")] Encounter encounter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encounter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BossID = new SelectList(db.Bosses, "BossID", "BossName", encounter.BossID);
            return View("~/Views/Admin/Encounters/Edit.cshtml", encounter);
        }

        // GET: Encounters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encounter encounter = db.Encounter.Find(id);
            if (encounter == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Encounters/Delete.cshtml", encounter);
        }

        // POST: Encounters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encounter encounter = db.Encounter.Find(id);
            db.Encounter.Remove(encounter);
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
