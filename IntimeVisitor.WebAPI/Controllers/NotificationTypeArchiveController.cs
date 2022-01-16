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
    public class NotificationTypeArchiveController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var BrachList = context.NotificationTypeArchives.Where(v => v.IsDeleted == false).ToList();
            return Ok(BrachList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] NotificationTypeArchive notificationTypeArchive)
        {
            if (ModelState.IsValid)
            {
                context.NotificationTypeArchives.Add(notificationTypeArchive);
                notificationTypeArchive.IsDeleted = false;
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
        public IHttpActionResult Edit(Guid id, [FromBody] NotificationTypeArchive notificationTypeArchive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var nta = context.NotificationTypeArchives.Find(id);



                if (nta != null)
                {
                    nta.NotificationTypeName = notificationTypeArchive.NotificationTypeName;
                    nta.ServerDescription = notificationTypeArchive.ServerDescription;
                    nta.ServerInfo = notificationTypeArchive.ServerInfo;
                    // brc.AddressId = brnc.AddressId;
                    
                    nta.ModifiedDate = DateTime.Now;
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
            var deleteBr = context.NotificationTypeArchives.SingleOrDefault(m => m.Id == id);

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
