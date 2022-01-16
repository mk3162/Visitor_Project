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
    public class ActivationController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var Activation = context.Activations.Where(v => v.IsDeleted == false).ToList();
            return Ok(Activation);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] Activation activation)
        {
            if (ModelState.IsValid)
            {
                context.Activations.Add(activation);
                activation.IsDeleted = false;
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
        public IHttpActionResult Edit(Guid id, [FromBody] Activation activation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var act = context.Activations.Find(id);



                if (act != null)
                {
                    act.NotifiactionTypeId = activation.NotifiactionTypeId;
                    act.UserId = activation.UserId;
                    act.NotifiactionDate = activation.NotifiactionDate;
                    act.ModifiedDate = DateTime.Now;
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
            var deleteBr = context.Activations.SingleOrDefault(m => m.Id == id);

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
