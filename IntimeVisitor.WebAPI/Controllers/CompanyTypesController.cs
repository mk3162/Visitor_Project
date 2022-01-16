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
    public class CompanyTypesController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var CompanyTypeList = context.CompanyTypes.Where(c => c.IsDeleted == false).ToList();
            return Ok(CompanyTypeList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] CompanyType typeadd)
        {
            if (ModelState.IsValid)
            {
                context.CompanyTypes.Add(typeadd);
                typeadd.IsDeleted = false;
                typeadd.Status = true;
                context.SaveChanges();


                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }

        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] CompanyType companyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var Comtypp = context.CompanyTypes.Find(id);



                if (Comtypp != null)
                {
                    Comtypp.CompanyTypeName = companyType.CompanyTypeName;
                    Comtypp.Status = companyType.Status;
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
            
            var deleteCmp = context.CompanyTypes.SingleOrDefault(m => m.Id == id);
           

            
            if (deleteCmp != null)
            {
                deleteCmp.IsDeleted = true;
                deleteCmp.DeletedDate = DateTime.Now;
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
