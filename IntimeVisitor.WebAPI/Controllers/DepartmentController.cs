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
    public class DepartmentController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var DepartmentList = context.Departments.Where(v => v.IsDeleted == false).ToList();
            return Ok(DepartmentList);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Department depadd)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(depadd);

                depadd.IsDeleted = false;

                context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                
                var dp = context.Departments.Find(id);
                


                if (dp != null)
                {
                    dp.DepartmentName = department.DepartmentName;
                    dp.BranchId = department.BranchId;

                    dp.ModifiedDate = DateTime.Now;
                    //cmp.IsDeleted = company.IsDeleted;
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
            
            var deleteDep = context.Departments.SingleOrDefault(m => m.Id == id);
            
            if (deleteDep != null)
            {
                deleteDep.IsDeleted = true;
                deleteDep.DeletedDate = DateTime.Now;
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
