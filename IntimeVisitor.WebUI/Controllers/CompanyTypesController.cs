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
    public class CompanyTypesController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        CompanyTypeManager companyTypeManager = new CompanyTypeManager(new CompanyTypeDAL());
        // GET: CompanyTypes
        public ActionResult CompanyType()
        {
            //var CompanyTypeList = context.CompanyTypes.Where(c => c.IsDeleted == false).ToList();
            var CompanyTypeList = companyTypeManager.GetAllAsList();
            //try
            //{


            //}
            //catch (Exception)
            //{


            //}
            return View(CompanyTypeList);
        }
        

        public ActionResult GetCompanyType(Guid Id)
        {
            //var Comtyp = context.CompanyTypes.Find(Id);
            var Comtyp = companyTypeManager.Get(Id);
            return View("GetCompanyType", Comtyp);
        }

        public ActionResult UpdateCompanyType(CompanyType companyType)
        {
            //var Comtypp = context.CompanyTypes.Find(companyType.Id);
            //Comtypp.CompanyTypeName = companyType.CompanyTypeName;
            //Comtypp.Status = companyType.Status;
            //context.SaveChanges();
            companyTypeManager.Update(companyType);
            return RedirectToAction("CompanyType");

        }

        public ActionResult StatusUpdate(CompanyType companyType)
        {
            //var Comtypp = context.CompanyTypes.Find(companyType.Id);
            var Comtypp = companyTypeManager.Get(companyType.Id);
            if (Comtypp.Status == false)
            {
                Comtypp.Status = true;
                companyTypeManager.Update(Comtypp);
            }
            else
            {
                Comtypp.Status = false;
                companyTypeManager.Update(Comtypp);
            }

           
            return RedirectToAction("CompanyType");
        }
        [HttpPost]
        public ActionResult TypeAdd(CompanyType typeadd)
        {
            try
            {
                //context.CompanyTypes.Add(typeadd);
                //typeadd.IsDeleted = false;
                //typeadd.Status = true;
                
                //context.SaveChanges();
                companyTypeManager.Add(typeadd);


            }
            catch (Exception)
            {

                return View();
            }
            return RedirectToAction("CompanyType");
        }


        public ActionResult SoftDelete(Guid id)
        {
            //var deleteCmp = context.CompanyTypes.SingleOrDefault(m => m.Id == id);
            //deleteCmp.IsDeleted = true;
            //deleteCmp.DeletedDate = DateTime.Now;
            ////context.Titles.Remove(deleteTitle);

            //context.SaveChanges();
            companyTypeManager.Delete(id);

            return RedirectToAction("CompanyType");
        }
    }
}