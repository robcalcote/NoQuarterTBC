using NoQuarterTBC.DAL;
using NoQuarterTBC.Models;
using System.Data;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// This is the main Admin Page
// It will contain links to any of the CRUD 
// views for each table within the database.

namespace NoQuarterTBC.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        private NoQuarterTBCContext db = new NoQuarterTBCContext();

        // GET: AdminHome
        public ActionResult Index()
        {
            return View("~/Views/Admin/AdminHome/Index.cshtml");
        }
    }
}