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
    public class DashboardController : Controller
    {
        
        IntimeVisitorContext context = new IntimeVisitorContext();
        // GET: Dashboard

        
        public ActionResult Index()
        {
            ViewBag.DayVisitCount = context.VisitDetails.Where(b=>b.PlanStartDate.Day.ToString()==DateTime.Today.Day.ToString()).Count();
            ViewBag.TotalVisitCount = context.VisitDetails.Count();
            ViewBag.TotalVisitPointCount = context.VisitPoints.Count();
            ViewBag.IsActiveCompanies = context.Companies.Where(b=>b.IsDeleted==false).Count();
            ViewBag.TotalCompaniesCount = context.Companies.Count();
            ViewBag.BlackListCount = context.Users.Where(a=>a.IsBlocked==true).Count();
          //  ViewBag.LastTwoDaysData1 = context.VisitDetails.Where(b => b.StartDate.Day.ToString() == DateTime.Today.AddDays(-1).ToString()).Count();
          //  ViewBag.LastTwoDaysData2 = context.VisitDetails.Where(b => b.StartDate.Day.ToString() == DateTime.Today.AddDays(-2).ToString()).Count();
            //ViewBag.LastTwoDaysData= ViewBag.LastTwoDaysData1-
            return View();
        }
        //TODO: Diğer Dashboard Componentleri için action açılacak
        public ActionResult visitDetailNotStarted()
        {
            List<VisitDetail> visitDetailNotStartedList = context.VisitDetails.Where(x => x.PlanStartDate > DateTime.Now).ToList();
            return View(visitDetailNotStartedList);
        }

        public ActionResult Test() {

            return View();
        }
    }
}