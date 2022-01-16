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
    public class KvkkTextController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var kvkkList = context.kvkkTexts.Where(c => c.IsDeleted == false).ToList();
            return Ok(kvkkList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] KvkkText TextAdd)
        {
            if (ModelState.IsValid)
            {
                context.kvkkTexts.Add(TextAdd);
                TextAdd.IsDeleted = false;
                TextAdd.Status = true;
                context.SaveChanges();


                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
        [HttpDelete]
        public IHttpActionResult SoftDelete(Guid id)
        {
            
            var deletetext = context.kvkkTexts.SingleOrDefault(m => m.Id == id);
            
            if (deletetext != null)
            {
                deletetext.IsDeleted = true;
                deletetext.DeletedDate = DateTime.Now;
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
