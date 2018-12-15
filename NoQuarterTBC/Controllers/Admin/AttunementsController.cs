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
    public class AttunementsController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Attunements
        public ActionResult Index()
        {
            return View("~/Views/Admin/Attunements/Index.cshtml", db.Attunement.ToList());
        }

        // GET: Attunements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attunement attunement = db.Attunement.Find(id);
            if (attunement == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Attunements/Details.cshtml", attunement);
        }

        // GET: Attunements/Create
        public ActionResult Create()
        {
            return View("~/Views/Admin/Attunements/Create.cshtml");
        }

        // POST: Attunements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttuneID,AttuneName")] Attunement attunement)
        {
            if (ModelState.IsValid)
            {
                db.Attunement.Add(attunement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Admin/Attunements/Create.cshtml", attunement);
        }

        // GET: Attunements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attunement attunement = db.Attunement.Find(id);
            if (attunement == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Attunements/Edit.cshtml", attunement);
        }

        // POST: Attunements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttuneID,AttuneName")] Attunement attunement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attunement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/Attunements/Edit.cshtml", attunement);
        }

        // GET: Attunements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attunement attunement = db.Attunement.Find(id);
            if (attunement == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/Attunements/Delete.cshtml", attunement);
        }

        // POST: Attunements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attunement attunement = db.Attunement.Find(id);
            db.Attunement.Remove(attunement);
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
