using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntimeVisitor.WebAPI.Controllers
{
    [Authorize]
    public class NotificationSendController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var BrachList = context.NotificationSends.Where(v => v.IsDeleted == false).ToList();
            return Ok(BrachList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] NotificationSend notificationSend)
        {
            if (ModelState.IsValid)
            {
                context.NotificationSends.Add(notificationSend);
                notificationSend.IsDeleted = false;
                //BrcAdd.Location = "-";
                context.SaveChanges();


                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] NotificationSend notificationSend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var ns = context.NotificationSends.Find(id);



                if (ns != null)
                {
                    ns.UserId = notificationSend.UserId;
                    ns.NotificationMessageId = notificationSend.NotificationMessageId;
                    ns.NotificationTypeId = notificationSend.NotificationTypeId;
                    ns.WorkflowId = notificationSend.WorkflowId;
                    ns.IsSend = notificationSend.IsSend;
                    ns.SendDate = notificationSend.SendDate;
                    ns.ServerIp = notificationSend.ServerIp;
                    ns.ModifiedDate = DateTime.Now;
                    context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok();
            }


        }
        [HttpDelete]
        public IHttpActionResult SoftDelete(Guid id)
        {
            var deleteBr = context.NotificationSends.SingleOrDefault(m => m.Id == id);

            if (deleteBr != null)
            {
                deleteBr.IsDeleted = true;
                deleteBr.DeletedDate = DateTime.Now;
                //context.Titles.Remove(deleteTitle);

                context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
    }
}
