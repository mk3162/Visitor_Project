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
    public class DepartmentController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        DepartmentManager departmentManager = new DepartmentManager(new DepartmentDAL());
        CompanyManager companyManager = new CompanyManager(new CompanyDAL());
        BranchManager branchManager = new BranchManager(new BranchDAL());
        // GET: Department
        public ActionResult DepartmentList()
        {
            List<SelectListItem> branch =
           context.Branches.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.BranchName + " / "  + i.Company.Name + " / ",
                Value = i.Id.ToString()
            }).ToList();
            ViewBag.branch = branch;
            var DepartmentList = departmentManager.GetAllAsList();
            return View(DepartmentList);
        }

        public ActionResult GetDepartment(Guid id)  // İd Getiriyoruz 
        {
            var dgr = departmentManager.Get(id);
            return View("GetDepartment",dgr);
        }


        [HttpGet]
        public ActionResult GetCompany()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var entity = context.Companies.Where(a => a.IsDeleted == false).ToList();
            return Json(entity, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBranch(Guid? companyId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(context.Branches.Where(a => a.IsDeleted == false && a.CompanyId == companyId).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            departmentManager.Update(department);
            return RedirectToAction("DepartmentList");
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department depadd)
        {
            try
            {
                departmentManager.Add(depadd);
            }
            catch
            {
                return View("DepartmentList");
            }
            return RedirectToAction("DepartmentList");
        }


        public ActionResult SoftDelete(Guid id)
        {
            departmentManager.Delete(id);
            return RedirectToAction("DepartmentList");
        }

    }
}