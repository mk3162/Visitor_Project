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
    public class WorkflowController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var workflows = context.Workflows.Where(v => v.IsDeleted == false).ToList();
            return Ok(workflows);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] Workflow workflow)
        {
            if (ModelState.IsValid)
            {
                context.Workflows.Add(workflow);
                workflow.IsDeleted = false;
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
        public IHttpActionResult Edit(Guid id, [FromBody] Workflow workflow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var wf = context.Workflows.Find(id);



                if (wf != null)
                {
                    wf.WorkflowStepId = workflow.WorkflowStepId;
                    wf.WorkflowName = workflow.WorkflowName;
                    wf.ModifiedDate = DateTime.Now;
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
            var deleteBr = context.Workflows.SingleOrDefault(m => m.Id == id);

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
