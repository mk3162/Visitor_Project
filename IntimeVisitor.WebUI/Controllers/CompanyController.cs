using IntimeVisitor.Bussiness.Concrete;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]
    public class CompanyController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        CompanyManager companyManager = new CompanyManager(new CompanyDAL());
        CompanyTypeManager companyTypeManager = new CompanyTypeManager(new CompanyTypeDAL());
        // GET: Company
        public ActionResult CompanyList()
        {
            List<SelectListItem> ads =
            context.Addresses.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.Openaddress + " - " + i.City,
                Value = i.Id.ToString()

            }).ToList();
            ViewBag.address = ads;



            List<SelectListItem> Cmp =
               context.CompanyTypes.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
               {
                   Text = i.CompanyTypeName,
                   Value = i.Id.ToString()
               }).ToList();

            ViewBag.companies = Cmp;
            var Company = companyManager.GetAllAsList();
            return View(Company);
        }
        public ActionResult GetCompany(Guid id)
        {
            List<SelectListItem> ads =
            context.Addresses.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.Openaddress + " - " + i.City,
                Value = i.Id.ToString()

            }).ToList();

            ViewBag.address = ads;

            List<SelectListItem> Cmp =
              context.CompanyTypes.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
              {
                  Text = i.CompanyTypeName,
                  Value = i.Id.ToString()
              }).ToList();

            ViewBag.companiestype = Cmp;

            var cmid = companyManager.Get(id);
            return View("GetCompany", cmid);

        }
        //Güncelleme İşlemi 
        public ActionResult UpdateCompany(Company company)
        {
            if (Request.Files.Count > 0)
            {
                string DosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string Uzanti = Path.GetExtension(Request.Files[0].FileName);
                string Yol = "~/CompanyLogoImage/" + DosyaAdi;
                Request.Files[1].SaveAs(Server.MapPath(Yol));
                company.CompanyImageFile = "/CompanyLogoImage/" + DosyaAdi;

                companyManager.Update(company);
                return RedirectToAction("CompanyList");
            }
            else
            {
                return RedirectToAction("CompanyList");
            }

          
        }


        [HttpGet]
        public ActionResult GetCompanyType()
        {

            context.Configuration.ProxyCreationEnabled = false;
            var entity = companyTypeManager.GetAllAsList().Where(a => a.IsDeleted == false && a.Status == true).ToList();
            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string TypeAdd(string companyTypeName)
        {
            CompanyType companyType = new CompanyType();
            companyType.CompanyTypeName = companyTypeName;
            try
            {
                companyTypeManager.Add(companyType);
            }
            catch (Exception)
            {

                return "basarisiz";
            }
            return companyType.Id.ToString(); //hidden bir alana bas sonra gönderirken name'ine companytypeId ver
        }


        public ActionResult CompanyAdd(Company CmpAdd)
        {
            if (Request.Files.Count>0)
            {
                string DosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string Uzanti = Path.GetExtension(Request.Files[0].FileName);
                string Yol ="~/CompanyLogoImage/"+DosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(Yol));
                CmpAdd.CompanyImageFile= "/CompanyLogoImage/" + DosyaAdi ;
                
                companyManager.Add(CmpAdd);
                return RedirectToAction("CompanyList");
            }
            else
            {
                return RedirectToAction("CompanyList");
            }


        }

        public ActionResult Typefind(string typ)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(companyTypeManager.GetAllAsList().Where(a => a.IsDeleted == false && a.CompanyTypeName == typ).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SoftDelete(Guid id)
        {
            companyManager.Delete(id);
            return RedirectToAction("CompanyList");
        }
    }
}