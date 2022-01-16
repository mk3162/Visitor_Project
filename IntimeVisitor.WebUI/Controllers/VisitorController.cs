using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]
    public class VisitorController : Controller
    {

        IntimeVisitorContext context = new IntimeVisitorContext();
        // GET: Visitor
        public ActionResult Index()
        {
            List<SelectListItem> usrt = context.Users.Where(a => a.UserType.UserTypeName != "ZİYARETÇİ" && a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.Name + "  " + i.SurName + " -  " + " Firma :" + i.Company.Name,
                Value = i.Company.Name,
            }).ToList();

            ViewBag.usrt = usrt;

            List<SelectListItem> attendies = context.Users.Where(a => a.UserType.UserTypeName != "ZİYARETÇİ" && a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.Name + "  " + i.SurName + " -  " + " Firma :" + i.Company.Name,
                Value = i.Id.ToString(),
            }).ToList();

            ViewBag.attendies = attendies;

            List<SelectListItem> usr = context.Users.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.Name + "   " + i.SurName + "   " + " :" + i.Department.Branch.Company.Name,
                Value = i.Id.ToString(),
            }).ToList();

            ViewBag.usr = usr;

            //List<SelectListItem> comp = context.Companies.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //}).ToList();

            //ViewBag.cmp = comp;


            List<SelectListItem> brc = context.Branches.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.BranchName,
                Value = i.Company.Name,

            }).ToList();

            ViewBag.brc = brc;




            List<SelectListItem> dep = context.Departments.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.DepartmentName,
                Value = i.Branch.BranchName,

            }).ToList();

            ViewBag.dep = dep;

            List<SelectListItem> po = context.VisitPoints.Where(a => a.IsDeleted == false).Select(i => new SelectListItem
            {
                Text = i.VisitPointName,
                Value = i.Department.DepartmentName,
            }).ToList();

            ViewBag.poo = po;

            VMVisitDetailAdd vMVisitDetailAdd = new VMVisitDetailAdd();
            vMVisitDetailAdd.visit = new Visit();
            vMVisitDetailAdd.attendiesArray = context.Users.Select(m => m.Id).ToArray();
            return View(vMVisitDetailAdd);
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
            var List = context.VisitDetails.Where(a=>a.IsDeleted==false).OrderBy(a=>a.VisitStatus).OrderByDescending(a=>a.PlanStartDate).ToList();
            return View(List);
        }
        public ActionResult VisitorListDetails()
        {
            return View();
        }
        //ÖMER
        //Guid IdVisit;
        //[HttpPost]
        //public ActionResult VisitorAdd(VMVisitDetailAdd vMVisitDetailAdd)
        //{ 

        //     // TODOO:Ekleme işlemini yapıyor fakat VisitPointId boş geliyor . Ekliyormuş gibi yapıyor fakat eklemiyor . 
        //    VisitDetail visitDetail = new VisitDetail();
        //    List<SelectListItem> usrt = context.Users.Where(a => a.UserType.UserTypeName != "ZİYARETÇİ" && a.IsDeleted == false && a.Status==true).Select(i => new SelectListItem
        //    {

        //        Text = i.Name + "  " + i.SurName + " -  " + " Firma :" + i.Company.Name,
        //        Value = i.Company.Name,
        //    }).ToList();

        //    ViewBag.usrt = usrt;
        //    //foreach (var userGuid in vMVisitDetailAdd.attendiesArray)
        //    //{
        //    //    visitDetail.AttendiesIds += userGuid.ToString() + ",";
        //    //}


        //    visitDetail.VisitStatus = "1";
        //    IdVisit = vMVisitDetailAdd.visit.Id;

        //    visitDetail.VisitId = IdVisit;

        //    Convert.ToDateTime(visitDetail.PlanStartDate).Date.ToLongDateString();
        //   visitDetail.PlanStartTime = Convert.ToDateTime(visitDetail.PlanStartDate.ToLongTimeString());
        //    Convert.ToDateTime(visitDetail.PlanEndDate).Date.ToLongTimeString();
        //    visitDetail.PlanEndTime = Convert.ToDateTime(visitDetail.PlanEndDate.ToLongTimeString());
        //    visitDetail.UserId = visitDetail.Visit_UserId;
        //    context.Visits.Add(vMVisitDetailAdd.visit);
        //    context.VisitDetails.Add(visitDetail);
        //    if (visitDetail.PlanEndDate < visitDetail.PlanStartDate)
        //    {

        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        //try
        //        //{
        //            context.SaveChanges();
        //            IdVisit.ToString(null);
        //        //}
        //        //catch (Exception exc)
        //        //{

        //            //return RedirectToAction("Index");
        //        //}

        //    }


        //    return RedirectToAction("Index");

        //}


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




            return RedirectToAction("Index");

        }
        public ActionResult DetailList() 
        {
            var lst = context.VisitDetails.Where(a=>a.VisitStatus=="1"&&a.IsDeleted==false).OrderByDescending(a=>a.PlanStartDate).ToList();
            return View(lst);
        }
        public ActionResult DetailList2()
        {
            var lst = context.VisitDetails.Where(a => a.VisitStatus == "2" && a.IsDeleted==false).OrderByDescending(a => a.PlanStartDate).ToList();
            return View(lst);
        }
        public ActionResult GetDetail(Guid Id)
        {
            //var typ = context.VisitDetails.Find(id);
            //return View("GetDetail", typ);
            var vDetail = context.VisitDetails.Find(Id);
            vDetail.VisitStatus = "2";
            context.SaveChanges();
          


            return RedirectToAction("DetailList");

        }
        ///Visitor/GetDetail2/@item.Id
        public ActionResult StartVisit(VisitDetail visitDetail)
        {
            var vstd = context.VisitDetails.Find(visitDetail.Id);
            
            vstd.VisitStatus = visitDetail.VisitStatus;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult GetDetail2(Guid Id ,Notes notes,string noteTitle,string noteDetails)
        {
            //var typ = context.VisitDetails.Find(id);
            //return View("GetDetail", typ);
            var vDetail = context.VisitDetails.Find(Id);

            vDetail.VisitStatus = "3";
            var noteInDb = context.Notes.Where(X => X.Id == notes.Id).FirstOrDefault();
            if (noteInDb != null)
            {
                noteInDb.NoteDetails = notes.NoteDetails;
                noteInDb.NoteTitle = notes.NoteTitle;

            }
            else
                context.Notes.Add(notes);

            //var nt = context.Notes.Add(notes);
            //nt.VisitDetailId = Id ;
            //nt.NoteTitle = noteTitle;
            //nt.NoteDetails = noteDetails;
            //nt.VisitDetailId = Id;

            context.SaveChanges();
            //TODOO:HATALI


            return View("GetDetail2");

        }

        public ActionResult EndVisit(VisitDetail visitDetail)
        {
            var vstd = context.VisitDetails.Find(visitDetail.Id);

            vstd.VisitStatus = visitDetail.VisitStatus;
            context.SaveChanges();
            return RedirectToAction("Index");

        }


        
        public ActionResult GetVisitDetail(Guid id)
        {
            var brctype = context.VisitDetails.Find(id);
            return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult UpdateVisitDetail(VisitDetail visitDetail , Visit visit)
        {
            var visitId = context.Visits.Find(visit.Id);
            var vDetail = context.VisitDetails.Find(visitDetail.Id);
            vDetail.PlanStartDate = visitDetail.PlanStartDate;
            vDetail.PlanStartTime = visitDetail.PlanStartTime;
            vDetail.PlanEndDate = visitDetail.PlanEndDate;
            vDetail.PlanEndTime = visitDetail.PlanEndTime;
            vDetail.VisitId = visitId.Id;
            vDetail.VisitPointId = visitDetail.VisitPointId;
            vDetail.UserId = visitDetail.UserId;
            vDetail.Visit_UserId = visitDetail.Visit_UserId;
            vDetail.VisitStatus = visitDetail.VisitStatus;
            vDetail.AllDay = visitDetail.AllDay;
            vDetail.IsApproved = visitDetail.IsApproved;
            vDetail.Code = visitDetail.Code;
            vDetail.CreatedBy = visitDetail.CreatedBy;
            vDetail.CreatedDate = visitDetail.CreatedDate;
            vDetail.ModifiedBy = vDetail.ModifiedBy;
            vDetail.ModifiedDate = DateTime.Now;
            vDetail.VisitStatus = "1";
            context.SaveChanges();

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



            return RedirectToAction("Index");


        }

        public ActionResult SoftDelete(Guid id)
        {
            var deleteVd = context.VisitDetails.SingleOrDefault(m => m.Id == id);
            deleteVd.IsDeleted = true;
            deleteVd.VisitStatus = "4";
            deleteVd.DeletedDate = DateTime.Now;
            
            //context.Titles.Remove(deleteTitle);

            context.SaveChanges();
            //branchTypeManager.Delete(id);
            return RedirectToAction("VisitorList");
        }

        public ActionResult ApprovedList() 
        {

            var List = context.VisitDetails.Where(a => a.IsDeleted == false &&  a.IsApproved=="3").OrderBy(a => a.VisitStatus).OrderByDescending(a => a.PlanStartDate).ToList();
            return View(List);

        }
    }
}