using IntimeVisitor.Bussiness.Concrete;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.Entities.ViewModel.VisitPoint;
using IntimeVisitor.WebUI.Extension;
using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]
    public class UserController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        UserManager userManager = new UserManager(new UserDAL());
        // GET: User
        public ActionResult UserList()
        {
            List<SelectListItem> Cmp =

             context.Companies.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
             {
                 Text = i.Name,
                 Value = i.Id.ToString()
             }).ToList();

            ViewBag.companies = Cmp;


            List<SelectListItem> UserTypes =

             context.UserTypes.Where(a => a.IsDeleted == false && a.Status == true).Select(i => new SelectListItem
             {
                 Text = i.UserTypeName,
                 Value = i.Id.ToString()
             }).ToList();

            ViewBag.types = UserTypes;

            var UserList = userManager.GetAllAsList();
            return View(UserList);
        }

        [HttpPost]
        public ActionResult UserAdd(User userAdd)
        {
            var log = context.Users.FirstOrDefault(x => x.EPosta == userAdd.EPosta);
            if (log == null)
            {
                userAdd.Status = true;
                userAdd.IsBlocked = false;
                userAdd.IsActive = true;
                userAdd.Password = Membership.GeneratePassword(6, 1);
                userManager.Add(userAdd);

                string Mesaj = "<br>" +
                    "Intime Visitor Giriş Eposta: " + userAdd.EPosta +
                    "<br>" +
                    "Intime Visitor Giriş Şifre : " + userAdd.Password
                    ;


                Helper.MailGonder(Mesaj, userAdd.EPosta); // Mesaj metni hazırla
                return RedirectToAction("UserList");
            }
            else
            {
                ViewBag.RegisterError = "Girmiş oldugunuz mail adresi sistemde kayıtlı";
                return RedirectToAction("UserList");
            }



            //MAİL GÖNDERMEDEN KAYIT YAPAN KODLAR
            //try
            //{

            //    context.Users.Add(userAdd);
            //    userAdd.IsDeleted = false;
            //    userAdd.Status = true;
            //    userAdd.Password = Membership.GeneratePassword(6, 1);
            //    context.SaveChanges();

            //}
            //catch (Exception)
            //{
            //    return RedirectToAction("UserList");

            //}
            //return RedirectToAction("UserList");
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
            return Json(context.Branches.Where(a => a.IsDeleted == false && a.CompanyId == companyId).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDepartment(Guid? branchId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(context.Departments.Where(a => a.IsDeleted == false && a.BranchId == branchId).ToList(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult SoftDelete(Guid id)
        {
            userManager.Delete(id);
            return RedirectToAction("UserList");
        }
        public ActionResult UserDailyVisitPanel()
        {

            VisitPointMeetingVM visitPointMeetingVM = new VisitPointMeetingVM();

            //visitPointMeetingVM.visitDetails = context.VisitDetails.Where(a => a.StartDate.Day == DateTime.Now.Day && a.VisitStatus != "3").Distinct().ToList();
            visitPointMeetingVM.visitDetails = context.VisitDetails.Where(a => a.PlanStartDate.Day == DateTime.Now.Day&&a.IsDeleted==false).Distinct().ToList();
            visitPointMeetingVM.visitPointNames = visitPointMeetingVM.visitDetails.Where(a => a.PlanStartDate.Day == DateTime.Now.Day).Select(x => x.VisitPoint.VisitPointName).Distinct().ToList();
            //visitPointMeetingVM.visitPointNames = visitPointMeetingVM.visitDetails.Where(a => a.StartDate.Day == DateTime.Now.Day && a.VisitStatus!="3").Select(x=>x.VisitPoint.VisitPointName).Distinct().ToList();
            //var lst = context.VisitDetails.Where(a=>a.StartDate.Day == DateTime.Now.Day).ToList(); // Çalışan Kısım Basic
            //var lst = (from num in context.VisitDetails
            //           select num).Where(a => a.StartDate.Day == DateTime.Now.Day).Distinct().ToList();

            return View(visitPointMeetingVM);
        }
        public ActionResult GetUser(Guid id)
        {
            List<SelectListItem> UserTypes =

           context.UserTypes.Select(i => new SelectListItem
           {
               Text = i.UserTypeName,
               Value = i.Id.ToString()
           }).ToList();

            ViewBag.types = UserTypes;

            List<SelectListItem> Cmp =

             context.Companies.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
             {
                 Text = i.Name,
                 Value = i.Id.ToString()
             }).ToList();

            ViewBag.companies = Cmp;

            List<SelectListItem> Brc =

            context.Branches.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.BranchName,
                Value = i.Id.ToString()
            }).ToList();

            ViewBag.branch = Brc;
            List<SelectListItem> Dep =

            context.Departments.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.DepartmentName,
                Value = i.Id.ToString()
            }).ToList();

            ViewBag.department = Dep;


            var cmid = userManager.Get(id);
            return View("GetUser", cmid);

        }
        
        [HttpPost]
        //Güncelleme İşlemi 
        public ActionResult UpdateUser(User userU)
        {
            //var u = context.Users.Find(userU.Id);
            //u.Name = userU.UserName;
            //u.SurName = userU.SurName;
            //u.RegisterNo = userU.RegisterNo;
            //u.TCNo = userU.TCNo;
            //u.FatherName = userU.FatherName;
            //u.MotherName = userU.MotherName;
            //u.Gender = userU.Gender;
            //u.BirthPlace = userU.BirthPlace;
            //u.BirthDate = userU.BirthDate;
            //u.Address = userU.Address;
            //u.EPosta = userU.EPosta;
            //u.EPostaKep = userU.EPostaKep;
            //u.Phone = userU.Phone;
            //u.Password = userU.Password;
            //u.UserTypeId = userU.UserTypeId;
            //u.UserName = userU.UserName;
            //u.Password = userU.Password;
            //u.Status = userU.Status;
            //u.DepartmentId = userU.DepartmentId;
            //u.IsActive = userU.IsActive;
            //u.Code = userU.Code;
            //context.SaveChanges();
            //var entity = userManager.Get(userU.Id);
            userManager.Update(userU);
            return RedirectToAction("UserList");
        }
    }
}