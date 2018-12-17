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
    public class EncounterLootsController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: EncounterLoots
        public ActionResult Index()
        {
            var encounterLoot = db.EncounterLoot.Include(e => e.loots).Include(e => e.players);
            return View("~/Views/Admin/EncounterLoots/Index.cshtml", encounterLoot.ToList());
        }

        // GET: EncounterLoots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncounterLoot encounterLoot = db.EncounterLoot.Find(id);
            if (encounterLoot == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/EncounterLoots/Details.cshtml", encounterLoot);
        }

        // GET: EncounterLoots/Create
        public ActionResult Create()
        {
            ViewBag.LootID = new SelectList(db.Loot, "LootID", "LootName");
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName");
            ViewBag.EncounterID = new SelectList(db.Encounter, "EncounterID", "EncounterID");
            return View("~/Views/Admin/EncounterLoots/Create.cshtml");
        }

        // POST: EncounterLoots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,LootID,EncounterID,Disenchanted")] EncounterLoot encounterLoot)
        {
            if (ModelState.IsValid)
            {
                db.EncounterLoot.Add(encounterLoot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LootID = new SelectList(db.Loot, "LootID", "LootName", encounterLoot.LootID);
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", encounterLoot.PlayerID);
            ViewBag.EncounterID = new SelectList(db.Encounter, "EncounterID", "EncounterID", encounterLoot.EncounterID);
            return View("~/Views/Admin/EncounterLoots/Create.cshtml", encounterLoot);
        }

        // GET: EncounterLoots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncounterLoot encounterLoot = db.EncounterLoot.Find(id);
            if (encounterLoot == null)
            {
                return HttpNotFound();
            }
            ViewBag.LootID = new SelectList(db.Loot, "LootID", "LootName", encounterLoot.LootID);
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", encounterLoot.PlayerID);
            return View("~/Views/Admin/EncounterLoots/Edit.cshtml", encounterLoot);
        }

        // POST: EncounterLoots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,LootID,EncounterID,Disenchanted")] EncounterLoot encounterLoot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encounterLoot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LootID = new SelectList(db.Loot, "LootID", "LootName", encounterLoot.LootID);
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", encounterLoot.PlayerID);
            return View("~/Views/Admin/EncounterLoots/Edit.cshtml", encounterLoot);
        }

        // GET: EncounterLoots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncounterLoot encounterLoot = db.EncounterLoot.Find(id);
            if (encounterLoot == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/EncounterLoots/Delete.cshtml", encounterLoot);
        }

        // POST: EncounterLoots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EncounterLoot encounterLoot = db.EncounterLoot.Find(id);
            db.EncounterLoot.Remove(encounterLoot);
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
