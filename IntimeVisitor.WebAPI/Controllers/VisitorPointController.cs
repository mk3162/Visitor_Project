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
    public class VisitorPointController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var VisitorPointList = context.VisitPoints.Where(a => a.IsDeleted == false).ToList();
            return Ok(VisitorPointList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] VisitPoint poadd)
        {
            if (ModelState.IsValid)
            {
                context.VisitPoints.Add(poadd);
                poadd.IsDeleted = false;
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
        public IHttpActionResult Edit(Guid id, [FromBody] VisitPoint visitPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                
                var vp = context.VisitPoints.Find(id);
                


                if (vp != null)
                {
                    vp.VisitPointName = visitPoint.VisitPointName;
                    vp.DepartmantId = visitPoint.DepartmantId;

                    vp.ModifiedDate = DateTime.Now;

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
            
            var deletePoint = context.VisitPoints.SingleOrDefault(m => m.Id == id);
            
            if (deletePoint != null)
            {
                deletePoint.IsDeleted = true;
                deletePoint.DeletedDate = DateTime.Now;
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
