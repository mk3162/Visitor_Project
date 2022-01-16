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
    public class ClarificationTextController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();

        [HttpGet]
        public IHttpActionResult Index()
        {
            var ClarificationList = context.ClarificationTexts.Where(c => c.IsDeleted == false).ToList();
            return Ok(ClarificationList);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] ClarificationText TextAdd)
        {
            if (ModelState.IsValid)
            {
                TextAdd.IsDeleted = false;
                TextAdd.Status = true;
                context.ClarificationTexts.Add(TextAdd);
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
            var deleteText = context.ClarificationTexts.SingleOrDefault(m => m.Id == id);
            if (deleteText != null)
            {
                deleteText.IsDeleted = true;
                deleteText.DeletedDate = DateTime.Now;
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
