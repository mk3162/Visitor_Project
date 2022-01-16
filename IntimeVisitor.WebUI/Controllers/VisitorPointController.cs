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
    public class VisitorPointController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        VisitPointManager visitPointManager = new VisitPointManager(new VisitPointDAL());

        public ActionResult VisitorPointList()
        {
            List<SelectListItem> Dep =
          context.Departments.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
          {
              
              Text = "Firma Adı : " + i.Branch.Company.Name + " / Şube Adı : " + i.Branch.BranchName + "  / Departman Adı :  " + i.DepartmentName ,
              Value = i.Id.ToString()
          }).ToList();
            ViewBag.Brn = Dep;

            var visitpoint = visitPointManager.GetAllAsList();
            return View(visitpoint);         
        }

        public ActionResult GetVisitorPoint(Guid id) 
        {
            var dgr = visitPointManager.Get(id);
            return View("GetVisitorPoint",dgr);
        }

        public ActionResult UpdateVisitorPoint(VisitPoint visitPoint)
        {
            visitPointManager.Update(visitPoint);
            return RedirectToAction("VisitorPointList");
        }



        [HttpPost]
        public ActionResult PointAdd(VisitPoint pointAdd)
        {

            //Department selecteddepartment = context.Departments.Where(x => x.Id == poadd.DepartmantId).FirstOrDefault();
            //poadd.Department = selecteddepartment;
           
                visitPointManager.Add(pointAdd);
                return RedirectToAction("VisitorPointList");       
        }


        public ActionResult SoftDelete(Guid id)
        {
            visitPointManager.Delete(id);
            return RedirectToAction("VisitorPointList");
        }

        [HttpGet]
        public ActionResult GetCompany()
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(context.Companies.Where(a => a.IsDeleted == false).ToList(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetBranch(Guid? companyId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(context.Branches.Where(a => a.IsDeleted == false && a.CompanyId ==  companyId).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDepartment(Guid? branchId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(context.Departments.Where(a => a.IsDeleted == false && a.BranchId == branchId).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}