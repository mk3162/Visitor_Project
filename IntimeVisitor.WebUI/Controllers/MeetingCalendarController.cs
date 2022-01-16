using IntimeVisitor.WebUI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    public class MeetingCalendarController : Controller
    {
        // GET: MeetingCalendar
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetMeetings()
        {
            using (MeetingDBEntities db = new MeetingDBEntities())
            {
                var meetings = db.Meetings.ToList();
                return new JsonResult { Data = meetings, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveMeeting(Meeting m)
        {
            var status = false;
            using (MeetingDBEntities db = new MeetingDBEntities())
            {
                if (m.MeetingId > 0)
                {
                    //Update the meeting
                    var updatedMeeting = db.Meetings.Where(x => x.MeetingId == m.MeetingId).FirstOrDefault();
                    if (updatedMeeting != null)
                    {
                        updatedMeeting.Subject = m.Subject;
                        updatedMeeting.Start = m.Start;
                        updatedMeeting.End = m.End;
                        updatedMeeting.Description = m.Description;
                        updatedMeeting.IsFullDay = m.IsFullDay;
                        updatedMeeting.ThemeColor = m.ThemeColor;
                    }
                }
                else
                {
                    //Add the meeting
                    db.Meetings.Add(m);
                }

                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteMeeting(int meetingID)
        {
            var status = false;

            using (MeetingDBEntities db = new MeetingDBEntities())
            {
                var deletedMeeting = db.Meetings.Where(x => x.MeetingId == meetingID).FirstOrDefault();
                if (deletedMeeting != null)
                {
                    db.Meetings.Remove(deletedMeeting);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
