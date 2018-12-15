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
    public class BankContributionsController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: BankContributions
        public ActionResult Index()
        {
            var bankContribution = db.BankContribution.Include(b => b.players);
            return View("~/Views/Admin/BankContributions/Index.cshtml", bankContribution.ToList());
        }

        // GET: BankContributions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankContribution bankContribution = db.BankContribution.Find(id);
            if (bankContribution == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/BankContributions/Details.cshtml", bankContribution);
        }

        // GET: BankContributions/Create
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName");
            return View("~/Views/Admin/BankContributions/Create.cshtml");
        }

        // POST: BankContributions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContributionID,PlayerID,ContributionItem,ContributionQuantity,ContributionDate")] BankContribution bankContribution)
        {
            if (ModelState.IsValid)
            {
                db.BankContribution.Add(bankContribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", bankContribution.PlayerID);
            return View("~/Views/Admin/BankContributions/Create.cshtml", bankContribution);
        }

        // GET: BankContributions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankContribution bankContribution = db.BankContribution.Find(id);
            if (bankContribution == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", bankContribution.PlayerID);
            return View("~/Views/Admin/BankContributions/Edit.cshtml", bankContribution);
        }

        // POST: BankContributions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContributionID,PlayerID,ContributionItem,ContributionQuantity,ContributionDate")] BankContribution bankContribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankContribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", bankContribution.PlayerID);
            return View("~/Views/Admin/BankContributions/Edit.cshtml", bankContribution);
        }

        // GET: BankContributions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankContribution bankContribution = db.BankContribution.Find(id);
            if (bankContribution == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/BankContributions/Delete.cshtml", bankContribution);
        }

        // POST: BankContributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankContribution bankContribution = db.BankContribution.Find(id);
            db.BankContribution.Remove(bankContribution);
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
