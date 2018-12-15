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
    public class PlayerProfessionsController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: PlayerProfessions
        public ActionResult Index()
        {
            var playerProfession = db.PlayerProfession.Include(p => p.players).Include(p => p.professions);
            return View("~/Views/Admin/PlayerProfessions/Index.cshtml", playerProfession.ToList());
        }

        // GET: PlayerProfessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerProfession playerProfession = db.PlayerProfession.Find(id);
            if (playerProfession == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/PlayerProfessions/Details.cshtml", playerProfession);
        }

        // GET: PlayerProfessions/Create
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName");
            ViewBag.ProfessionID = new SelectList(db.Profession, "ProfessionID", "ProfessionName");
            return View("~/Views/Admin/PlayerProfessions/Create.cshtml");
        }

        // POST: PlayerProfessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,ProfessionID")] PlayerProfession playerProfession)
        {
            if (ModelState.IsValid)
            {
                db.PlayerProfession.Add(playerProfession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", playerProfession.PlayerID);
            ViewBag.ProfessionID = new SelectList(db.Profession, "ProfessionID", "ProfessionName", playerProfession.ProfessionID);
            return View("~/Views/Admin/PlayerProfessions/Create.cshtml", playerProfession);
        }

        // GET: PlayerProfessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerProfession playerProfession = db.PlayerProfession.Find(id);
            if (playerProfession == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", playerProfession.PlayerID);
            ViewBag.ProfessionID = new SelectList(db.Profession, "ProfessionID", "ProfessionName", playerProfession.ProfessionID);
            return View("~/Views/Admin/PlayerProfessions/Edit.cshtml", playerProfession);
        }

        // POST: PlayerProfessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,ProfessionID")] PlayerProfession playerProfession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerProfession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", playerProfession.PlayerID);
            ViewBag.ProfessionID = new SelectList(db.Profession, "ProfessionID", "ProfessionName", playerProfession.ProfessionID);
            return View("~/Views/Admin/PlayerProfessions/Edit.cshtml", playerProfession);
        }

        // GET: PlayerProfessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerProfession playerProfession = db.PlayerProfession.Find(id);
            if (playerProfession == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/PlayerProfessions/Delete.cshtml", playerProfession);
        }

        // POST: PlayerProfessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerProfession playerProfession = db.PlayerProfession.Find(id);
            db.PlayerProfession.Remove(playerProfession);
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
