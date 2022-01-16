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
    public class RolesController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        UserRolesManager userRolesManager = new UserRolesManager(new UserRolesDAL());
        // GET: Roles
        public ActionResult Role()
        {
            var rr = userRolesManager.GetAllAsList();
            return View(rr);
        }
        public ActionResult GetUsers()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var getUsers = context.Users.Where(x => x.IsDeleted == false).ToList();
            return Json(getUsers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRole(Guid id)

        {
            var typ = userRolesManager.Get(id);
            return View("GetRole", typ);
        }

        public ActionResult GetUpdate(UserRoles urol)
        {
            userRolesManager.Update(urol);
            return RedirectToAction("Role");
        }


        public ActionResult RoleAdd(UserRoles roles)
        {
            try
            {
                userRolesManager.Add(roles);
            }
            catch (Exception)
            {

                return RedirectToAction("Role");
            }
            return RedirectToAction("Role");
        }

        public ActionResult SoftDelete(Guid id)
        {
            userRolesManager.Delete(id);
            return RedirectToAction("Role");
        }
    }
}