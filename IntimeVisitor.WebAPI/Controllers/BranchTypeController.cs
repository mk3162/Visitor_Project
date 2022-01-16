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
    public class BranchTypeController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        
        
        [HttpGet]
        public IHttpActionResult Index()
        {
            var BranchTypeList = context.BranchTypes.Where(v => v.IsDeleted == false).ToList();
            return Ok(BranchTypeList);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] BranchType branchType)
        {
            if (ModelState.IsValid)
            {
                context.BranchTypes.Add(branchType);
                branchType.Status = true;
                branchType.IsDeleted = false;
                context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }

        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] BranchType branchType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var Comtypp = context.BranchTypes.Find(id);

                if (Comtypp != null)
                {
                    Comtypp.BranchTypeName = branchType.BranchTypeName;
                    Comtypp.Status = branchType.Status;

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
            var deleteBr = context.BranchTypes.SingleOrDefault(m => m.Id == id);
            
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
