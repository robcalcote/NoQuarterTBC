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
    public class PrivilegesController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Privileges
        public ActionResult Index()
        {
            var right = db.Right.Include(p => p.roles);
            return View("~/Views/Admin/Privileges/Index.cshtml", right.ToList());
        }

        // GET: Privileges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilege privilege = db.Right.Find(id);
            if (privilege == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Privileges/Details.cshtml", privilege);
        }

        // GET: Privileges/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName");
            return View("~/Views/Admin/Privileges/Create.cshtml");
        }

        // POST: Privileges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RightsID,RoleID,RightsName")] Privilege privilege)
        {
            if (ModelState.IsValid)
            {
                db.Right.Add(privilege);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName", privilege.RoleID);
            return View("~/Views/Admin/Privileges/Create.cshtml", privilege);
        }

        // GET: Privileges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilege privilege = db.Right.Find(id);
            if (privilege == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName", privilege.RoleID);
            return View("~/Views/Admin/Privileges/Edit.cshtml", privilege);
        }

        // POST: Privileges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RightsID,RoleID,RightsName")] Privilege privilege)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privilege).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleName", privilege.RoleID);
            return View("~/Views/Admin/Privileges/Edit.cshtml", privilege);
        }

        // GET: Privileges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilege privilege = db.Right.Find(id);
            if (privilege == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Privileges/Delete.cshtml", privilege);
        }

        // POST: Privileges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Privilege privilege = db.Right.Find(id);
            db.Right.Remove(privilege);
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
