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
    public class VisitDetailController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();

        [HttpGet]

        public IHttpActionResult Index()
        {
            var visitDetails = context.VisitDetails.Where(v => v.IsDeleted == false).ToList();
            return Ok(visitDetails);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] VisitDetail visitDetail)
        {
            if (ModelState.IsValid)
            {
                visitDetail.IsDeleted = false;
                context.VisitDetails.Add(visitDetail);
                
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
        public IHttpActionResult Edit(Guid id, [FromBody] VisitDetail visitDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var vstDetail = context.VisitDetails.Find(id);



                if (vstDetail != null)
                {
                    vstDetail.PlanStartDate = visitDetail.PlanStartDate;
                    vstDetail.PlanStartTime = visitDetail.PlanStartTime;
                    vstDetail.PlanEndDate = visitDetail.PlanEndDate;
                    vstDetail.PlanEndTime = visitDetail.PlanEndTime;
                    vstDetail.VisitPointId = visitDetail.VisitPointId;
                    vstDetail.VisitId = visitDetail.VisitId;
                    vstDetail.UserId = visitDetail.UserId;
                    vstDetail.LastVisitDetailId = visitDetail.LastVisitDetailId;
                    vstDetail.VisitStatus = visitDetail.VisitStatus;
                    vstDetail.Visit_UserId = visitDetail.Visit_UserId;
                    vstDetail.ModifiedDate = DateTime.Now;
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
            var deleteBr = context.VisitDetails.SingleOrDefault(m => m.Id == id);

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
