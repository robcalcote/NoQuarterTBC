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
    public class GuildRanksController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: GuildRanks
        public ActionResult Index()
        {
            return View("~/Views/Admin/GuildRanks/Index.cshtml", db.GuildRank.ToList());
        }

        // GET: GuildRanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuildRank guildRank = db.GuildRank.Find(id);
            if (guildRank == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/GuildRanks/Details.cshtml", guildRank);
        }

        // GET: GuildRanks/Create
        public ActionResult Create()
        {
            return View("~/Views/Admin/GuildRanks/Create.cshtml");
        }

        // POST: GuildRanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RankID,RankName")] GuildRank guildRank)
        {
            if (ModelState.IsValid)
            {
                db.GuildRank.Add(guildRank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Admin/GuildRanks/Create.cshtml", guildRank);
        }

        // GET: GuildRanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuildRank guildRank = db.GuildRank.Find(id);
            if (guildRank == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/GuildRanks/Edit.cshtml", guildRank);
        }

        // POST: GuildRanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RankID,RankName")] GuildRank guildRank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guildRank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/GuildRanks/Edit.cshtml", guildRank);
        }

        // GET: GuildRanks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuildRank guildRank = db.GuildRank.Find(id);
            if (guildRank == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/GuildRanks/Delete.cshtml", guildRank);
        }

        // POST: GuildRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuildRank guildRank = db.GuildRank.Find(id);
            db.GuildRank.Remove(guildRank);
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
