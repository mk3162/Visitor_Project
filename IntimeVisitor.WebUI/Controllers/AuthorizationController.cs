using IntimeVisitor.Entities.Context;
using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]
    public class AuthorizationController : Controller
    {

        IntimeVisitorContext context = new IntimeVisitorContext();
       
        public ActionResult Index()
        {
            return View();
        }
    }
}