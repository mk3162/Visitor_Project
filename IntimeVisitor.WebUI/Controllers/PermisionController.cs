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
    public class PermisionController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        PermisonManager permisonManager = new PermisonManager(new PermisionDAL());
        // GET: Permision
        public ActionResult Permisions()
        {
            var perlist = permisonManager.GetAllAsList();
            return View(perlist);
        }

        public ActionResult PermisionGet(Guid id) 
        
        {
            var typ = permisonManager.Get(id);
            return View("PermisionGet", typ);
        
        
        }

        public ActionResult PermisionUpdate(Permision peru)
        {
            permisonManager.Update(peru);
            return RedirectToAction("Permisions");
        }

        public ActionResult PermisionAdd(Permision per)
        {

            try
            {
                permisonManager.Add(per);


            }
            catch (Exception)
            {

                return RedirectToAction("Permisions");
            }
            return RedirectToAction("Permisions");
        }

        public ActionResult SoftDelete(Guid id)
        {
            permisonManager.Delete(id);
            return RedirectToAction("Permisions");
        }
    }
}