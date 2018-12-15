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
    public class LootsController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Loots
        public ActionResult Index()
        {
            var loot = db.Loot.Include(l => l.bosses);
            return View("~/Views/Admin/Loots/Index.cshtml", loot.ToList());
        }

        // GET: Loots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loot loot = db.Loot.Find(id);
            if (loot == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Loots/Details.cshtml", loot);
        }

        // GET: Loots/Create
        public ActionResult Create()
        {
            ViewBag.BossID = new SelectList(db.Bosses, "BossID", "BossName");
            return View("~/Views/Admin/Loots/Create.cshtml");
        }

        // POST: Loots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LootID,LootName,BossID")] Loot loot)
        {
            if (ModelState.IsValid)
            {
                db.Loot.Add(loot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BossID = new SelectList(db.Bosses, "BossID", "BossName", loot.BossID);
            return View("~/Views/Admin/Loots/Create.cshtml", loot);
        }

        // GET: Loots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loot loot = db.Loot.Find(id);
            if (loot == null)
            {
                return HttpNotFound();
            }
            ViewBag.BossID = new SelectList(db.Bosses, "BossID", "BossName", loot.BossID);
            return View("~/Views/Admin/Loots/Edit.cshtml", loot);
        }

        // POST: Loots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LootID,LootName,BossID")] Loot loot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BossID = new SelectList(db.Bosses, "BossID", "BossName", loot.BossID);
            return View("~/Views/Admin/Loots/Edit.cshtml", loot);
        }

        // GET: Loots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loot loot = db.Loot.Find(id);
            if (loot == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Loots/Delete.cshtml", loot);
        }

        // POST: Loots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loot loot = db.Loot.Find(id);
            db.Loot.Remove(loot);
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
