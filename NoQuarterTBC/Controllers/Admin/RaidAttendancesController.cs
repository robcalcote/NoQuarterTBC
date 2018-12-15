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
    public class RaidAttendancesController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: RaidAttendances
        public ActionResult Index()
        {
            var raidAttendance = db.RaidAttendance.Include(r => r.players).Include(r => r.raidinstances);
            return View("~/Views/Admin/RaidAttendances/Index.cshtml", raidAttendance.ToList());
        }

        // GET: RaidAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaidAttendance raidAttendance = db.RaidAttendance.Find(id);
            if (raidAttendance == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/RaidAttendances/Details.cshtml", raidAttendance);
        }

        // GET: RaidAttendances/Create
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName");
            ViewBag.RaidInstanceID = new SelectList(db.RaidInstance, "RaidInstanceID", "RaidInstanceID");
            return View("~/Views/Admin/RaidAttendances/Create.cshtml");
        }

        // POST: RaidAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttendanceID,PlayerID,RaidInstanceID,TotalAttendance,RecentAttendance")] RaidAttendance raidAttendance)
        {
            if (ModelState.IsValid)
            {
                db.RaidAttendance.Add(raidAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", raidAttendance.PlayerID);
            ViewBag.RaidInstanceID = new SelectList(db.RaidInstance, "RaidInstanceID", "RaidInstanceID", raidAttendance.RaidInstanceID);
            return View("~/Views/Admin/RaidAttendances/Create.cshtml", raidAttendance);
        }

        // GET: RaidAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaidAttendance raidAttendance = db.RaidAttendance.Find(id);
            if (raidAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", raidAttendance.PlayerID);
            ViewBag.RaidInstanceID = new SelectList(db.RaidInstance, "RaidInstanceID", "RaidInstanceID", raidAttendance.RaidInstanceID);
            return View("~/Views/Admin/RaidAttendances/Edit.cshtml", raidAttendance);
        }

        // POST: RaidAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendanceID,PlayerID,RaidInstanceID,TotalAttendance,RecentAttendance")] RaidAttendance raidAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raidAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", raidAttendance.PlayerID);
            ViewBag.RaidInstanceID = new SelectList(db.RaidInstance, "RaidInstanceID", "RaidInstanceID", raidAttendance.RaidInstanceID);
            return View("~/Views/Admin/RaidAttendances/Edit.cshtml", raidAttendance);
        }

        // GET: RaidAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaidAttendance raidAttendance = db.RaidAttendance.Find(id);
            if (raidAttendance == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/RaidAttendances/Delete.cshtml", raidAttendance);
        }

        // POST: RaidAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RaidAttendance raidAttendance = db.RaidAttendance.Find(id);
            db.RaidAttendance.Remove(raidAttendance);
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
