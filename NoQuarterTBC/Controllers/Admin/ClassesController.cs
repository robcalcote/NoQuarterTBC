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
    public class ClassesController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Classes
        public ActionResult Index()
        {
            return View("~/Views/Admin/Classes/Index.cshtml", db.Class.ToList());
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Class.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Classes/Details.cshtml", @class);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            return View("~/Views/Admin/Classes/Create.cshtml");
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,ClassName")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Class.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Admin/Classes/Create.cshtml", @class);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Class.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Classes/Edit.cshtml", @class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassID,ClassName")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/Specs/Edit.cshtml", @class);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Class.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Classes/Delete.cshtml", @class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Class.Find(id);
            db.Class.Remove(@class);
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
