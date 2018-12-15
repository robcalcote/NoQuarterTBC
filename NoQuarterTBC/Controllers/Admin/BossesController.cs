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
    public class BossesController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Bosses
        public ActionResult Index()
        {
            var bosses = db.Bosses.Include(b => b.raids);
            return View("~/Views/Admin/Bosses/Index.cshtml", bosses.ToList());
        }

        // GET: Bosses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boss boss = db.Bosses.Find(id);
            if (boss == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Bosses/Details.cshtml", boss);
        }

        // GET: Bosses/Create
        public ActionResult Create()
        {
            ViewBag.RaidID = new SelectList(db.Raid, "RaidID", "RaidName");
            return View("~/Views/Admin/Bosses/Create.cshtml");
        }

        // POST: Bosses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BossID,BossName,RaidID")] Boss boss)
        {
            if (ModelState.IsValid)
            {
                db.Bosses.Add(boss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RaidID = new SelectList(db.Raid, "RaidID", "RaidName", boss.RaidID);
            return View("~/Views/Admin/Bosses/Create.cshtml", boss);
        }

        // GET: Bosses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boss boss = db.Bosses.Find(id);
            if (boss == null)
            {
                return HttpNotFound();
            }
            ViewBag.RaidID = new SelectList(db.Raid, "RaidID", "RaidName", boss.RaidID);
            return View("~/Views/Admin/Bosses/Edit.cshtml", boss);
        }

        // POST: Bosses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BossID,BossName,RaidID")] Boss boss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RaidID = new SelectList(db.Raid, "RaidID", "RaidName", boss.RaidID);
            return View("~/Views/Admin/Bosses/Edit.cshtml", boss);
        }

        // GET: Bosses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boss boss = db.Bosses.Find(id);
            if (boss == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Bosses/Delete.cshtml", boss);
        }

        // POST: Bosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boss boss = db.Bosses.Find(id);
            db.Bosses.Remove(boss);
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
