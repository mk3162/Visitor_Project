using IntimeVisitor.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers.Reports
{
    public class BlockedListController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        // GET: BlokedList
        public ActionResult BlockedList()
        {
            var blockedlist = context.Users.Where(a=>a.IsBlocked==true).ToList();
            return View(blockedlist);
        }
    }
}