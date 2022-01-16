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
    public class BranchController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        BranchManager branchManager = new BranchManager(new BranchDAL());
        CompanyManager companyManager = new CompanyManager(new CompanyDAL());
        BranchTypeManager branchTypeManager = new BranchTypeManager(new BranchTypeDAL());
        AddressManager addressManager = new AddressManager(new AddressDAL());
        // GET: Branch
        public ActionResult Branch()
        {
            List<SelectListItem> cmp =
          context.Companies.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
          {
              Text = i.Name + " - " + i.Address.City,
              Value = i.Id.ToString()
          }).ToList();
            ViewBag.cmp = cmp;

            List<SelectListItem> ads =
           context.Addresses.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
           {
               Text = i.Openaddress + " - " + i.Country,
               Value = i.Id.ToString()

           }).ToList();
            ViewBag.address = ads;


            List<SelectListItem> Branchtype =
           context.BranchTypes.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
           {
               Text = i.BranchTypeName,
               Value = i.Id.ToString()
           }).ToList();
            ViewBag.Btype = Branchtype;

            var BrachList = branchManager.GetAllAsList();
            return View(BrachList);
        }

        public ActionResult GetBranch(Guid id)
        {
            List<SelectListItem> cmp =
        context.Companies.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
        {
            Text = i.Name + " - " + i.Address.City,
            Value = i.Id.ToString()
        }).ToList();
            ViewBag.cmp = cmp;

            List<SelectListItem> ads =
           context.Addresses.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
           {
               Text = i.Openaddress + " - " + i.Country,
               Value = i.Id.ToString()

           }).ToList();
            ViewBag.address = ads;


            List<SelectListItem> Branchtype =
           context.BranchTypes.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
           {
               Text = i.BranchTypeName,
               Value = i.Id.ToString()
           }).ToList();
            ViewBag.Btype = Branchtype;

            var dgr = branchManager.Get(id);
            return View("GetBranch",dgr);

        }

        public ActionResult UpdateBranch(Branch brnc)
        {
          

            branchManager.Update(brnc);
            return RedirectToAction("Branch");

        }



        [HttpPost]
        public ActionResult BranchAdd(Branch BrcAdd)
        {

            branchManager.Add(BrcAdd);
            return RedirectToAction("Branch");

        }
        public ActionResult SoftDelete(Guid id)
        {
           
            branchManager.Delete(id);
            return RedirectToAction("Branch");
        }

        public ActionResult Cmpfind(string cmp)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(companyManager.GetAllAsList().Where(a => a.IsDeleted == false && a.Name == cmp).ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetCompany()
        {

            context.Configuration.ProxyCreationEnabled = false;
            var entity = context.Companies.Where(a => a.IsDeleted == false).ToList();
            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string CompanyAdd(string companyName)
        {
            Company company = new Company();
            company.Name = companyName;
            try
            {
                companyManager.Add(company);
            }
            catch (Exception)
            {

                return "basarisiz";
            }
            return company.Id.ToString(); //hidden bir alana bas sonra gönderirken name'ine companytypeId ver
        }

        public ActionResult BrcTypefind(string brc)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(branchTypeManager.GetAllAsList().Where(a => a.IsDeleted == false && a.BranchTypeName == brc).ToList(), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetBranchType()
        {

            context.Configuration.ProxyCreationEnabled = false;
            var entity = context.BranchTypes.Where(a => a.IsDeleted == false).ToList();
            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string BranchTypeAdd(string branchTypeName)
        {
            BranchType branchtype = new BranchType();
            branchtype.BranchTypeName = branchTypeName;
            try
            {
                branchTypeManager.Add(branchtype);
            }
            catch (Exception)
            {

                return "basarisiz";
            }
            return branchtype.Id.ToString(); //hidden bir alana bas sonra gönderirken name'ine companytypeId ver
        }
    }
}