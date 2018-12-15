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
    public class PlayerAttunementsController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: PlayerAttunements
        public ActionResult Index()
        {
            var playerAttunement = db.PlayerAttunement.Include(p => p.players);
            return View("~/Views/Admin/PlayerAttunements/Index.cshtml", playerAttunement.ToList());
        }

        // GET: PlayerAttunements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerAttunement playerAttunement = db.PlayerAttunement.Find(id);
            if (playerAttunement == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/PlayerAttunements/Details.cshtml", playerAttunement);
        }

        // GET: PlayerAttunements/Create
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName");
            return View("~/Views/Admin/PlayerAttunements/Create.cshtml");
        }

        // POST: PlayerAttunements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,AttunementID,DateAchieved")] PlayerAttunement playerAttunement)
        {
            if (ModelState.IsValid)
            {
                db.PlayerAttunement.Add(playerAttunement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", playerAttunement.PlayerID);
            return View("~/Views/Admin/PlayerAttunements/Create.cshtml", playerAttunement);
        }

        // GET: PlayerAttunements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerAttunement playerAttunement = db.PlayerAttunement.Find(id);
            if (playerAttunement == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", playerAttunement.PlayerID);
            return View("~/Views/Admin/PlayerAttunements/Edit.cshtml", playerAttunement);
        }

        // POST: PlayerAttunements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,AttunementID,DateAchieved")] PlayerAttunement playerAttunement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerAttunement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", playerAttunement.PlayerID);
            return View("~/Views/Admin/PlayerAttunements/Edit.cshtml", playerAttunement);
        }

        // GET: PlayerAttunements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerAttunement playerAttunement = db.PlayerAttunement.Find(id);
            if (playerAttunement == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/PlayerAttunements/Delete.cshtml", playerAttunement);
        }

        // POST: PlayerAttunements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerAttunement playerAttunement = db.PlayerAttunement.Find(id);
            db.PlayerAttunement.Remove(playerAttunement);
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
