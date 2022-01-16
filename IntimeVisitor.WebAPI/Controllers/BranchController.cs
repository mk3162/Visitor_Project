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
    public class BranchController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();

        [HttpGet]

        public IHttpActionResult Index()
        {
            var BranchList = context.Branches.Where(v => v.IsDeleted == false).ToList();
            return Ok(BranchList);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Branch BrcAdd)
        {
            if (ModelState.IsValid)
            {
                context.Branches.Add(BrcAdd);
                BrcAdd.IsDeleted = false;
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
        public IHttpActionResult Edit(Guid id, [FromBody] Branch BrcAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var brc = context.Branches.Find(id);
                
                

                if (brc != null)
                {
                    brc.BranchName = BrcAdd.BranchName;
                    brc.BranchTypeId = BrcAdd.BranchTypeId;
                    brc.CompanyId = BrcAdd.CompanyId;
                    // brc.AddressId = brnc.AddressId;
                    brc.BranchPhoneNumber = BrcAdd.BranchPhoneNumber;
                    brc.BranchEMail = BrcAdd.BranchEMail;
                    brc.ModifiedDate = DateTime.Now;
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
            var deleteBr = context.Branches.SingleOrDefault(m => m.Id == id);

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
