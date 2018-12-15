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
    public class NotesController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: Notes
        public ActionResult Index()
        {
            var note = db.Note.Include(n => n.players);
            return View(note.ToList());
        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note notes = db.Note.Find(id);
            if (notes == null)
            {
                return HttpNotFound();
            }
            return View(notes);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NotesID,PlayerID,Note,NoteDate,PrivateNote")] Note notes)
        {
            if (ModelState.IsValid)
            {
                db.Note.Add(notes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", notes.PlayerID);
            return View(notes);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note notes = db.Note.Find(id);
            if (notes == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", notes.PlayerID);
            return View(notes);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotesID,PlayerID,Note,NoteDate,PrivateNote")] Note notes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", notes.PlayerID);
            return View(notes);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note notes = db.Note.Find(id);
            if (notes == null)
            {
                return HttpNotFound();
            }
            return View(notes);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note notes = db.Note.Find(id);
            db.Note.Remove(notes);
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
