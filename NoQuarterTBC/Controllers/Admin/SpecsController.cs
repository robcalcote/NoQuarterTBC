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
    public class SpecsController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Specs
        public ActionResult Index()
        {
            var spec = db.Spec.Include(s => s.classes).Include(s => s.gameroles);
            return View("~/Views/Admin/Specs/Index.cshtml", spec.ToList());
        }

        // GET: Specs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spec spec = db.Spec.Find(id);
            if (spec == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Specs/Details.cshtml", spec);
        }

        // GET: Specs/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Class, "ClassID", "ClassName");
            ViewBag.GameRoleID = new SelectList(db.GameRole, "GameRoleID", "GameRoleName");
            return View("~/Views/Admin/Specs/Create.cshtml");
        }

        // POST: Specs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecID,SpecName,GameRoleID,ClassID")] Spec spec)
        {
            if (ModelState.IsValid)
            {
                db.Spec.Add(spec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Class, "ClassID", "ClassName", spec.ClassID);
            ViewBag.GameRoleID = new SelectList(db.GameRole, "GameRoleID", "GameRoleName", spec.GameRoleID);
            return View("~/Views/Admin/Specs/Create.cshtml", spec);
        }

        // GET: Specs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spec spec = db.Spec.Find(id);
            if (spec == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Class, "ClassID", "ClassName", spec.ClassID);
            ViewBag.GameRoleID = new SelectList(db.GameRole, "GameRoleID", "GameRoleName", spec.GameRoleID);
            return View("~/Views/Admin/Specs/Edit.cshtml", spec);
        }

        // POST: Specs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecID,SpecName,GameRoleID,ClassID")] Spec spec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Class, "ClassID", "ClassName", spec.ClassID);
            ViewBag.GameRoleID = new SelectList(db.GameRole, "GameRoleID", "GameRoleName", spec.GameRoleID);
            return View("~/Views/Admin/Specs/Edit.cshtml", spec);
        }

        // GET: Specs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spec spec = db.Spec.Find(id);
            if (spec == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Specs/Delete.cshtml", spec);
        }

        // POST: Specs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spec spec = db.Spec.Find(id);
            db.Spec.Remove(spec);
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
