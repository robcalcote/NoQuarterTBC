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
    public class GameRolesController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: GameRoles
        public ActionResult Index()
        {
            return View("~/Views/Admin/GameRoles/Index.cshtml", db.GameRole.ToList());
        }

        // GET: GameRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameRole gameRole = db.GameRole.Find(id);
            if (gameRole == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/GameRoles/Details.cshtml", gameRole);
        }

        // GET: GameRoles/Create
        public ActionResult Create()
        {
            return View("~/Views/Admin/GameRoles/Create.cshtml");
        }

        // POST: GameRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameRoleID,GameRoleName")] GameRole gameRole)
        {
            if (ModelState.IsValid)
            {
                db.GameRole.Add(gameRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Admin/GameRoles/Create.cshtml", gameRole);
        }

        // GET: GameRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameRole gameRole = db.GameRole.Find(id);
            if (gameRole == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/GameRoles/Edit.cshtml", gameRole);
        }

        // POST: GameRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameRoleID,GameRoleName")] GameRole gameRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/GameRoles/Edit.cshtml", gameRole);
        }

        // GET: GameRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameRole gameRole = db.GameRole.Find(id);
            if (gameRole == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/GameRoles/Delete.cshtml", gameRole);
        }

        // POST: GameRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameRole gameRole = db.GameRole.Find(id);
            db.GameRole.Remove(gameRole);
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
