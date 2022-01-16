using DataLayer;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.Entities.SpModels;
using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]
    public class HomeController : Controller
    {
        public ActionResult Index()
        { 
            object obj = dbDAL.GetSpList<TestSpModel>("SpTest", new SqlParameter("@test", 1));
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

            return View();
        }
    }
}