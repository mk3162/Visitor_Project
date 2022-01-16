using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntimeVisitor.Bussiness.Concrete;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.WebUI.Session;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]
    public class UserTypeController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        UserTypeManager userTypeManager = new UserTypeManager(new UserTypeDAL());
        // GET: UserType
        public ActionResult UserType()
        {
            var UserTypes = userTypeManager.GetAllAsList();
            return View(UserTypes);

        }
        //Tip İd sini getiriyoruz
        public ActionResult GetType(Guid id)
        {
            var typ = userTypeManager.Get(id);
            return View("GetType", typ);

        }
        //Güncelleme İşlemi 
        public ActionResult Update(UserType uType)
        {
            userTypeManager.Update(uType);
            return RedirectToAction("UserType");
        }
        public ActionResult StatusUpdate(UserType userType)
        {
            var typp = userTypeManager.Get(userType.Id);
            if (typp.Status == false)
            {
                typp.Status = true;
                userTypeManager.Update(typp);
            }
            else
            {
               typp.Status = false;
                userTypeManager.Update(typp);
            }


            return RedirectToAction("UserType");
        }

        [HttpPost]
        public ActionResult UserTypeAdd(UserType userTypeAdd)
        {
            try
            {
                userTypeManager.Add(userTypeAdd);


            }
            catch (Exception)
            {
                return RedirectToAction("UserType");

            }
            return RedirectToAction("UserType");

        }


        public ActionResult SoftDelete(Guid id)
        {
            userTypeManager.Delete(id);
            return RedirectToAction("UserType");
        }


    }
}