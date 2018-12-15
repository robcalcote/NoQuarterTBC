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
    public class RaidsController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Raids
        public ActionResult Index()
        {
            return View("~/Views/Admin/Raids/Index.cshtml", db.Raid.ToList());
        }

        // GET: Raids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = db.Raid.Find(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Raids/Details.cshtml", raid);
        }

        // GET: Raids/Create
        public ActionResult Create()
        {
            return View("~/Views/Admin/Raids/Create.cshtml");
        }

        // POST: Raids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaidID,RaidName,RaidReleaseDate")] Raid raid)
        {
            if (ModelState.IsValid)
            {
                db.Raid.Add(raid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Admin/Raids/Create.cshtml", raid);
        }

        // GET: Raids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = db.Raid.Find(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Raids/Edit.cshtml", raid);
        }

        // POST: Raids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaidID,RaidName,RaidReleaseDate")] Raid raid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/Raids/Edit.cshtml", raid);
        }

        // GET: Raids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raid raid = db.Raid.Find(id);
            if (raid == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Raids/Delete.cshtml", raid);
        }

        // POST: Raids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raid raid = db.Raid.Find(id);
            db.Raid.Remove(raid);
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
