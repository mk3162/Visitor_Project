using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult UserSettings()
        {
            return View();
                
        }
    }
}