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
    public class PermisionController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var perlist = context.Permisions.Where(o => o.IsDeleted == false).ToList();
            return Ok(perlist);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Permision per)
        {
            if (ModelState.IsValid)
            {
                context.Permisions.Add(per);
                per.IsDeleted = false;

                context.SaveChanges();


                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] Permision peru)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                
                var typp = context.Permisions.Find(id);
                


                if (typp != null)
                {
                    typp.Name = peru.Name;
                    typp.Description = peru.Description;
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
            
            var deleteTitle = context.Permisions.SingleOrDefault(m => m.Id == id);
            
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
