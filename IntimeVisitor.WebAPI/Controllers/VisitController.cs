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
    public class VisitController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();

        [HttpGet]

        public IHttpActionResult Index()
        {
            var visit = context.Visits.Where(v => v.IsDeleted == false).ToList();
            return Ok(visit);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] Visit visit)
        {
            if (ModelState.IsValid)
            {
                visit.IsDeleted = false;
                context.Visits.Add(visit);

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
        public IHttpActionResult Edit(Guid id, [FromBody] Visit visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var vst = context.Visits.Find(id);



                if (vst != null)
                {
                    vst.QRCodeId = visit.QRCodeId;
                    vst.UserId = visit.UserId;

                    vst.ModifiedDate = DateTime.Now;
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
            var deleteBr = context.Visits.SingleOrDefault(m => m.Id == id);

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
