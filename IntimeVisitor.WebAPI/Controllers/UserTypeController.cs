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
    public class UserTypeController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var UserTypes = context.UserTypes.Where(v => v.IsDeleted == false).ToList();
            return Ok(UserTypes);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] UserType userTypeAdd)
        {
            if (ModelState.IsValid)
            {
                context.UserTypes.Add(userTypeAdd);
                userTypeAdd.IsDeleted = false;
                userTypeAdd.Status = true;
                context.SaveChanges();


                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] UserType uType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                
                var typp = context.UserTypes.Find(id);
                


                if (typp != null)
                {
                    typp.UserTypeName = uType.UserTypeName;
                    typp.Status = uType.Status;
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
            
            var deleteUserType = context.UserTypes.SingleOrDefault(m => m.Id == id);
            
            if (deleteUserType != null)
            {
                deleteUserType.IsDeleted = true;
                deleteUserType.DeletedDate = DateTime.Now;
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
