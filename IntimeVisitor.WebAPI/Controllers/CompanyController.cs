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
    public class CompanyController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]
        public IHttpActionResult Index()
        {
            var Company = context.Companies.Where(c => c.IsDeleted == false).ToList();
            return Ok(Company);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Company CmpAdd)
        {
            if (ModelState.IsValid)
            {
                context.Companies.Add(CmpAdd);
                CmpAdd.IsDeleted = false;
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
        public IHttpActionResult Edit(Guid id, [FromBody] Company CmpAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
               
                var cmp = context.Companies.Find(id);
                
                if (cmp != null)
                {
                    cmp.Name = CmpAdd.Name;

                    cmp.CompanyTypeId = CmpAdd.CompanyTypeId;
                    cmp.Title = CmpAdd.Title;
                    cmp.TaxAdministration = CmpAdd.TaxAdministration;
                    cmp.TaxNo = CmpAdd.TaxNo;
                    cmp.Phone = CmpAdd.Phone;
                    cmp.Fax = CmpAdd.Fax;
                    cmp.AddressId = CmpAdd.AddressId;
                    cmp.EMail = CmpAdd.EMail;
                    cmp.EMailKEP = CmpAdd.EMailKEP;
                    cmp.ModifiedDate = DateTime.Now;
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
            var deleteCmp = context.Companies.SingleOrDefault(m => m.Id == id);

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
