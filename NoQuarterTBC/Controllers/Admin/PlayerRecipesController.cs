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
    public class PlayerRecipesController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: PlayerRecipes
        public ActionResult Index()
        {
            var playerRecipe = db.PlayerRecipe.Include(p => p.players).Include(p => p.recipes);
            return View("~/Views/Admin/PlayerRecipes/Index.cshtml", playerRecipe.ToList());
        }

        // GET: PlayerRecipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerRecipe playerRecipe = db.PlayerRecipe.Find(id);
            if (playerRecipe == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/PlayerRecipes/Details.cshtml", playerRecipe);
        }

        // GET: PlayerRecipes/Create
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName");
            ViewBag.RecipeID = new SelectList(db.Recipe, "RecipeID", "RecipeName");
            return View("~/Views/Admin/PlayerRecipes/Create.cshtml");
        }

        // POST: PlayerRecipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,RecipeID")] PlayerRecipe playerRecipe)
        {
            if (ModelState.IsValid)
            {
                db.PlayerRecipe.Add(playerRecipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", playerRecipe.PlayerID);
            ViewBag.RecipeID = new SelectList(db.Recipe, "RecipeID", "RecipeName", playerRecipe.RecipeID);
            return View("~/Views/Admin/PlayerRecipes/Create.cshtml", playerRecipe);
        }

        // GET: PlayerRecipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerRecipe playerRecipe = db.PlayerRecipe.Find(id);
            if (playerRecipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", playerRecipe.PlayerID);
            ViewBag.RecipeID = new SelectList(db.Recipe, "RecipeID", "RecipeName", playerRecipe.RecipeID);
            return View("~/Views/Admin/PlayerRecipes/Edit.cshtml", playerRecipe);
        }

        // POST: PlayerRecipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,RecipeID")] PlayerRecipe playerRecipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerRecipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "PlayerName", playerRecipe.PlayerID);
            ViewBag.RecipeID = new SelectList(db.Recipe, "RecipeID", "RecipeName", playerRecipe.RecipeID);
            return View("~/Views/Admin/PlayerRecipes/Edit.cshtml", playerRecipe);
        }

        // GET: PlayerRecipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerRecipe playerRecipe = db.PlayerRecipe.Find(id);
            if (playerRecipe == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Admin/PlayerRecipes/Delete.cshtml", playerRecipe);
        }

        // POST: PlayerRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerRecipe playerRecipe = db.PlayerRecipe.Find(id);
            db.PlayerRecipe.Remove(playerRecipe);
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
