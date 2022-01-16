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
    public class MediaTypeController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();

        [HttpGet]
        public IHttpActionResult Index()
        {
            var MediaTypeList = context.MediaTypes.Where(v => v.IsDeleted == false).ToList();
            return Ok(MediaTypeList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] MediaType mediaType)
        {
            if (ModelState.IsValid)
            {
                context.MediaTypes.Add(mediaType);
                mediaType.Status = true;
                mediaType.IsDeleted = false;
                context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] MediaType mediaType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var medtypp = context.MediaTypes.Find(id);

                if (medtypp != null)
                {
                    medtypp.MediaTypeName = mediaType.MediaTypeName;
                    medtypp.Status = mediaType.Status;

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
            var deleteBr = context.MediaTypes.SingleOrDefault(m => m.Id == id);

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
