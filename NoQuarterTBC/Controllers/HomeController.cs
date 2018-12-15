using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/**************************************************************************************************
 *  Description:    Guild Website for No Quarter (NA)
 *  Build:          0.1
 *  DB Hosted On:   Microsoft Azure
 *  DB Diagram:     https://www.lucidchart.com/documents/edit/2fe6e207-765c-4a10-8167-666a6e089b3c/1
 *  Source Code:    https://github.com/robcalcote/NoQuarterTBC
 *  Collaborators:  Alexander Miner, Rob Calcote
 *************************************************************************************************/

namespace NoQuarterTBC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return RedirectToAction("Index", "Players");
        }
    }
}