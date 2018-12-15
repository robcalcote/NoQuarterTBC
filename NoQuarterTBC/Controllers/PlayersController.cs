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

namespace NoQuarterTBC.Controllers
{
    public class PlayersController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Players
        public ActionResult Index()
        {
            var player = db.Player.Include(p => p.classes).Include(p => p.roles).Include(p => p.specs);
            return View(player.ToList());
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Player.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.AssayTypeID = new SelectList(db.Class, "ClassID", "ClassName");
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName");
            ViewBag.SpecID = new SelectList(db.Spec, "SpecID", "SpecName");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,PlayerName,RoleID,AssayTypeID,SpecID,LoginPW")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Player.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssayTypeID = new SelectList(db.Class, "ClassID", "ClassName", player.AssayTypeID);
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName", player.RoleID);
            ViewBag.SpecID = new SelectList(db.Spec, "SpecID", "SpecName", player.SpecID);
            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Player.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssayTypeID = new SelectList(db.Class, "ClassID", "ClassName", player.AssayTypeID);
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName", player.RoleID);
            ViewBag.SpecID = new SelectList(db.Spec, "SpecID", "SpecName", player.SpecID);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,PlayerName,RoleID,AssayTypeID,SpecID,LoginPW")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssayTypeID = new SelectList(db.Class, "ClassID", "ClassName", player.AssayTypeID);
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName", player.RoleID);
            ViewBag.SpecID = new SelectList(db.Spec, "SpecID", "SpecName", player.SpecID);
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Player.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Player.Find(id);
            db.Player.Remove(player);
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
