using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoQuarterTBC.Models;
using NoQuarterTBC.DAL;
using System.Web.Security;
using System.Data.Entity;

namespace NoQuarterTBC.Controllers
{
    public class LoginController : Controller
    {
        NoQuarterTBCContext db = new NoQuarterTBCContext();
        protected System.Web.UI.HtmlControls.HtmlGenericControl divControl;

        // Login page : GET
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Login page : POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form, [Bind(Include = "PlayerID,PlayerName,LoginPW")] Player newplayer, bool rememberMe = false)
        {
            Player player = db.Player.SingleOrDefault(i => i.PlayerName == newplayer.PlayerName);
            string password = newplayer.LoginPW;
            ViewBag.SuccessfulLogin = null;

            if (player != null)
            {
                if (player.LoginPW == newplayer.LoginPW)
                {
                    FormsAuthentication.SetAuthCookie(newplayer.PlayerName, rememberMe);
                    HomeController.sBannerMessage = "Welcome! You have successfully Logged in.";
                    HomeController.bLoggedIn = true;
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "Your Username and/or Password were incorrect.";
            return View();
        }

        // Registration Page : GET
        public ActionResult Register()
        {
            // If the user is already logged in, they are not allowed to register for an account
            if (HomeController.bLoggedIn == true)
            {
                divControl.Style.Add("color", "red");
                HomeController.sBannerMessage = "You are already logged in, please logout before attempting to Register a new account.";
                RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

    }
}