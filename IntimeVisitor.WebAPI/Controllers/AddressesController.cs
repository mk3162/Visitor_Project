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
    public class AddressesController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        // GET: Addresses
        [HttpGet]
        public IHttpActionResult Index()
        {
            var AdressList = context.Addresses.Where(v => v.IsDeleted == false).ToList();
            return Ok(AdressList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] Address address)
        {
            if (ModelState.IsValid)
            {
                address.IsDeleted = false;
                context.Addresses.Add(address);
                context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }

        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var ads = context.Addresses.Find(id);
                
                if (ads != null)
                {
                    ads.Country = address.Country;
                    ads.City = address.City;
                    ads.District = address.District;
                    // brc.AddressId = brnc.AddressId;
                    ads.PostalCode = address.PostalCode;
                    ads.Openaddress = address.Openaddress;
                    ads.ModifiedDate = DateTime.Now;
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
            var deleteAddress = context.Addresses.SingleOrDefault(m => m.Id == id);
            if (deleteAddress != null)
            {
                deleteAddress.IsDeleted = true;
                deleteAddress.DeletedDate = DateTime.Now;


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
