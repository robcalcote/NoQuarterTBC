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
    public class RaidInstancesController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: RaidInstances
        public ActionResult Index()
        {
            var raidInstance = db.RaidInstance.Include(r => r.raids);
            return View("~/Views/Admin/RaidInstances/Index.cshtml", raidInstance.ToList());
        }

        // GET: RaidInstances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaidInstance raidInstance = db.RaidInstance.Find(id);
            if (raidInstance == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/RaidInstances/Details.cshtml", raidInstance);
        }

        // GET: RaidInstances/Create
        public ActionResult Create()
        {
            ViewBag.RaidID = new SelectList(db.Raid, "RaidID", "RaidName");
            return View("~/Views/Admin/RaidInstances/Create.cshtml");
        }

        // POST: RaidInstances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaidInstanceID,RaidID,RaidDate,Progression,RaidCleared,RaidRunTime")] RaidInstance raidInstance)
        {
            if (ModelState.IsValid)
            {
                db.RaidInstance.Add(raidInstance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RaidID = new SelectList(db.Raid, "RaidID", "RaidName", raidInstance.RaidID);
            return View("~/Views/Admin/RaidInstances/Create.cshtml", raidInstance);
        }

        // GET: RaidInstances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaidInstance raidInstance = db.RaidInstance.Find(id);
            if (raidInstance == null)
            {
                return HttpNotFound();
            }
            ViewBag.RaidID = new SelectList(db.Raid, "RaidID", "RaidName", raidInstance.RaidID);
            return View("~/Views/Admin/RaidInstances/Edit.cshtml", raidInstance);
        }

        // POST: RaidInstances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaidInstanceID,RaidID,RaidDate,Progression,RaidCleared,RaidRunTime")] RaidInstance raidInstance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raidInstance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RaidID = new SelectList(db.Raid, "RaidID", "RaidName", raidInstance.RaidID);
            return View("~/Views/Admin/RaidInstances/Edit.cshtml", raidInstance);
        }

        // GET: RaidInstances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaidInstance raidInstance = db.RaidInstance.Find(id);
            if (raidInstance == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/RaidInstances/Delete.cshtml", raidInstance);
        }

        // POST: RaidInstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RaidInstance raidInstance = db.RaidInstance.Find(id);
            db.RaidInstance.Remove(raidInstance);
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
