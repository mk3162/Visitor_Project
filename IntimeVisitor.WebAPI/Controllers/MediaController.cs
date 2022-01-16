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
    public class MediaController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();

        [HttpGet]
        public IHttpActionResult Index()
        {
            var MediaList = context.Medias.Where(v => v.IsDeleted == false).ToList();
            return Ok(MediaList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] Media media)
        {
            if (ModelState.IsValid)
            {
                context.Medias.Add(media);
                
                media.IsDeleted = false;
                context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var med = context.Medias.Find(id);

                if (med != null)
                {
                    med.FilePath = media.FilePath;
                    med.Extension = media.Extension;
                    med.MediaTypeId = media.MediaTypeId;
                    med.ModifiedDate = DateTime.Now;

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
            var deleteBr = context.Medias.SingleOrDefault(m => m.Id == id);

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
