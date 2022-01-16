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
    public class NotificationMessagesController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var NotificationMessages = context.NotificationMessages.Where(v => v.IsDeleted == false).ToList();
            return Ok(NotificationMessages);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] NotificationMessages notificationMessages)
        {
            if (ModelState.IsValid)
            {
                context.NotificationMessages.Add(notificationMessages);
                notificationMessages.IsDeleted = false;
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
        public IHttpActionResult Edit(Guid id, [FromBody] NotificationMessages notificationMessages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var nm = context.NotificationMessages.Find(id);


                if (nm != null)
                {
                    nm.MessageName = notificationMessages.MessageName;
                    nm.MessageDetails = notificationMessages.MessageDetails;
                    nm.ModifiedDate = DateTime.Now;
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
            var deleteBr = context.NotificationMessages.SingleOrDefault(m => m.Id == id);

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
