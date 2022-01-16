using IntimeVisitor.Bussiness.Concrete;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]
    public class ClarificationTextController : Controller
    {

        IntimeVisitorContext context = new IntimeVisitorContext();
        ClarificationTextManager clarificationTextManager = new ClarificationTextManager(new ClarificationTextDAL());
        // GET: ClarificationText
        public ActionResult ClarificationTextList()
        {
            List<SelectListItem> Cmp =
             
               context.Companies.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
               {
                   Text = i.Name,
                   Value = i.Id.ToString()
               }).ToList();

            ViewBag.companies = Cmp;
            var ClarificationList = clarificationTextManager.GetAllAsList();
            return View(ClarificationList);
        }


        [HttpPost]
        public ActionResult ClarificationTextAdd(ClarificationText TextAdd)
        {
            try
            {
                clarificationTextManager.Add(TextAdd);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("ClarificationTextList");

        }
        public ActionResult SoftDelete(Guid id)
        {
            clarificationTextManager.Delete(id);
            return RedirectToAction("ClarificationTextList");
        }
    }
}