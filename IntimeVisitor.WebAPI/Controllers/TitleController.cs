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
    public class TitleController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var TitleList = context.Titles.Where(c => c.IsDeleted == false).ToList();
            return Ok(TitleList);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Title titleadd)
        {
            if (ModelState.IsValid)
            {
                context.Titles.Add(titleadd);
                titleadd.IsDeleted = false;

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
            
            var deleteTitle = context.Titles.SingleOrDefault(m => m.Id == id);
            
            if (deleteTitle != null)
            {
                deleteTitle.IsDeleted = true;
                deleteTitle.DeletedDate = DateTime.Now;
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
