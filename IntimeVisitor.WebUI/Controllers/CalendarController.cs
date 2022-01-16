using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        IntimeVisitorContext context = new IntimeVisitorContext();
        public ActionResult Calendar()
        {
            var list = context.Users.ToList();
            return View(list);
        }
        //public JsonResult GetCalendarEvents()
        //{
        //    //List<VisitDetail> eventItems = new List<VisitDetail>();
        //    //int i = 0, n = 9;
        //    //for (i = 0; i < n; i++)
        //    //{
        //    //    AddItem(eventItems);
        //    //}

        //    //return Json(eventItems, JsonRequestBehavior.AllowGet);
        //}

        Random random = new Random();
        public void AddItem()
        {
            //VisitDetail item = new VisitDetail();

            //DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, random.Next(1, 30));

            ////item.Id = random.Next(1, 100);
            //item.StartTime = startDate;
            //item.EndTime = startDate.AddDays(random.Next(1, 5));
            //item.AllDay = true;
            //item.Color = "blue";
            ////item.Notes. = "Calendar Item";
            //eventItems.Add(item);
            
        }

    }
}