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
    public class WorkflowStepsController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var BrachList = context.WorkflowSteps.Where(v => v.IsDeleted == false).ToList();
            return Ok(BrachList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] WorkflowSteps workflowSteps)
        {
            if (ModelState.IsValid)
            {
                context.WorkflowSteps.Add(workflowSteps);
                workflowSteps.IsDeleted = false;
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
        public IHttpActionResult Edit(Guid id, [FromBody] WorkflowSteps workflowSteps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var wfs = context.WorkflowSteps.Find(id);



                if (wfs != null)
                {
                    wfs.WorkflowStepCode = workflowSteps.WorkflowStepCode;
                    wfs.StepNumber = workflowSteps.StepNumber;
                    wfs.StepDetails = workflowSteps.StepDetails;
                    wfs.MessageId = workflowSteps.MessageId;
                    wfs.ModifiedDate = DateTime.Now;
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
            var deleteBr = context.WorkflowSteps.SingleOrDefault(m => m.Id == id);

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
