using IntimeVisitor.Bussiness.Concrete;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]
    public class KvkkTextController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        KvkkTextManager kvkkTextManager = new KvkkTextManager(new KvkkTextDAL());
        public ActionResult KvkkTextList()
        {
            List<SelectListItem> Cmp =
            
                context.Companies.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList();

            ViewBag.companies = Cmp;

            var kvkkList = kvkkTextManager.GetAllAsList();

            return View(kvkkList);
        }


        [HttpPost]
        public ActionResult KvkkTextAdd(KvkkText TextAdd)
        {
            try
            {
                kvkkTextManager.Add(TextAdd);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("KvkkTextList");

        }
        public ActionResult SoftDelete(Guid id)
        {
            kvkkTextManager.Delete(id);
            return RedirectToAction("KvkkTextList");
        }
    }
}