using IntimeVisitor.Bussiness.Concrete;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.Entities.ViewModel.Calendar;
using IntimeVisitor.WebUI.Models;
using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    
    //[LoginAuth]
    public class CalenderController : Controller
    {
       IntimeVisitorContext context = new IntimeVisitorContext();
        VisitDetailManager visitDetailManager = new VisitDetailManager(new VisitDetailDAL());
     
        // GET: Calender
        public ActionResult Calender()
        {
            List<SelectListItem> usr = context.Users.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.Name + "   " + i.SurName + " -  " + " :" + i.Department.Branch.Company.Name,
                Value = i.Id.ToString(),
            }).ToList();

            ViewBag.usr = usr;
            return View();
        }
        public JsonResult GetAppointmentsByDentist(Guid userId)
        {
            var model = context.VisitDetails.Where(x => x.UserId == userId)
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,

                    PlanStartDate = x.PlanStartDate,
                    PlanStartTime = Convert.ToDateTime(x.PlanStartDate.ToShortTimeString()),
                   
                    PlanEndDate = x.PlanEndDate,
                    PlanEndTime = Convert.ToDateTime(x.PlanEndDate.ToShortTimeString()),
                 
                    UserId = x.User.Id
                }); ;

            return Json(model);
        }
        Guid IdVisit;
        [HttpPost]
        public ActionResult VisitorAdd(Visit visitAdd, VisitDetail visitDetail)
        {
            context.Visits.Add(visitAdd);
            context.VisitDetails.Add(visitDetail);
            visitAdd.IsDeleted = false;

            IdVisit = visitAdd.Id;

            visitDetail.VisitId = IdVisit;
            Convert.ToDateTime(visitDetail.PlanStartDate).Date.ToLongDateString();
            visitDetail.PlanStartTime = Convert.ToDateTime(visitDetail.PlanStartDate.ToLongTimeString());
            Convert.ToDateTime(visitDetail.PlanEndDate).Date.ToLongTimeString();
            visitDetail.PlanEndTime = Convert.ToDateTime(visitDetail.PlanEndDate.ToLongTimeString());
            visitDetail.UserId = visitDetail.Visit_UserId;

            context.SaveChanges();
            IdVisit.ToString(null);

            return RedirectToAction("Calender");

        }

        //public JsonResult GetAppointments()
        //{
        //    var model = context.VisitDetails
        //        .Include(x => x.User).Select(x => new AppointmentViewModel()
        //        {
        //            Id = x.Id,
        //            UserId = (Guid)x.UserId,
        //            Visit_UserId = (Guid)x.Visit_UserId,
        //            VisitPointId = (Guid)x.VisitPointId,
        //            VisitId = (Guid)x.VisitId,
        //            PlanStartDate = x.PlanStartDate,
        //            PlanEndDate = x.PlanEndDate,
        //        }); ;
        //    var deneme = "asdasd"

        //    return Json(deneme);
        //}

        [HttpGet]
        public ActionResult GetVisits()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var hh = context.VisitDetails.Include(a => a.User).Where(a => a.IsDeleted == false).ToList();
            return Json(hh, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetVisit1() {
        //    context.Configuration.ProxyCreationEnabled = false;
        //    var hh = context.VisitDetails.Where(a => a.IsDeleted == false).Include(a => a.User).Include(a => a.Visit).ToList();
        //    return Json(hh,JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult UpdateVisitDetail(VisitDetail visitDetail , Visit visit) 
        //{



        //    var v = context.Visits.Find(visit.Id);
        //    var vd = context.VisitDetails.Find(visitDetail.Id);
        //    vd.PlanStartDate = visitDetail.PlanStartDate;
        //    vd.PlanEndTime =Convert.ToDateTime(visitDetail.PlanStartDate.ToShortTimeString());
        //    vd.PlanEndDate = visitDetail.PlanEndDate;
        //    vd.PlanEndTime= Convert.ToDateTime(visitDetail.PlanEndDate.ToShortTimeString());
        //    vd.VisitId = visit.Id;

        //    context.SaveChanges();
        //    return RedirectToAction("Calender");

        //}
        //[HttpPost]
        //public JsonResult AddOrUpdateAppointment(AddOrUpdateAppointmentModel model)
        //{
        //    ////Validasyon
        //    //if (model.Id == null)
        //    //{
        //        VisitDetail entity = new VisitDetail()
        //        {



        //            CreatedDate = DateTime.Now,
        //            PlanStartDate = model.PlanStartDate,
        //            PlanEndDate = model.PlanEndDate,
        //            PlanStartTime = Convert.ToDateTime(model.PlanStartDate.ToShortTimeString()),
        //            PlanEndTime = Convert.ToDateTime(model.PlanEndDate.ToShortTimeString()),
        //            VisitId = model.VisitId,
        //            VisitPointId=model.VisitPointId,
        //            VisitStatus="3",
        //            // User = model.PatientName,
        //            Visit_UserId = model.Visit_UserId,
        //            // PatientSurname = model.PatientSurname,
        //            Notes = model.Notes,
        //            UserId = model.UserId
        //        };

        //        context.VisitDetails.Add(entity);
        //        context.SaveChanges();
        //    //}
        //    //else
        //    //{
        //    //    var entity = context.VisitDetails.SingleOrDefault(x => x.Id == model.Id);
        //    //    if (entity == null)
        //    //    {
        //    //        return Json("Güncellenecek veri bulunamadı.");
        //    //    }
        //    //    entity.ModifiedDate = DateTime.Now;
        //    //    entity.User.Name = model.User.Name;
        //    //    entity.User.SurName = model.User.SurName;
        //    //    entity.Visit.VisitNotes = model.Visit.VisitNotes;
        //    //    entity.PlanStartDate = model.PlanStartDate;
        //    //    entity.PlanEndDate = model.PlanEndDate;
        //    //    entity.UserId = model.UserId;

        //    //    //  context.VisitDetails(entity);
        //    //    context.SaveChanges();
        //    //}

        //    return Json("200");
        //}
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
        public ActionResult GetVisitorPoint(Guid? departmentId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(context.VisitPoints.Where(a => a.IsDeleted == false && a.DepartmantId == departmentId).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUserVisitor(Guid? departmentId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return Json(context.Users.Where(a => a.IsDeleted == false && a.DepartmentId == departmentId).ToList(), JsonRequestBehavior.AllowGet);
        }



        public JsonResult BranchList(Guid id)
        {

            List<SelectListItem> brc = context.Branches.Where(a => a.CompanyId == id).Select(i => new SelectListItem
            {
                Text = i.BranchName,
                Value = i.Id.ToString()
            }).ToList();

            //ViewBag.brc = brc;
            return Json(brc, JsonRequestBehavior.AllowGet);
        }
        public ActionResult VisitorList()
        {
            var List = context.VisitDetails.Where(a => a.IsDeleted == false).OrderBy(a => a.VisitStatus).OrderByDescending(a => a.PlanStartDate).ToList();
            return View(List);
        }
    }
}