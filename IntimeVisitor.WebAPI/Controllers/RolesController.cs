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
    public class RolesController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var roleList = context.Roles.Where(x => x.IsDeleted == false).ToList();
            return Ok(roleList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] UserRoles roles)
        {
            if (ModelState.IsValid)
            {
                context.Roles.Add(roles);
                roles.IsDeleted = false;

                context.SaveChanges();


                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] UserRoles urol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                var typp = context.Roles.Find(id);
                



                if (typp != null)
                {
                    typp.RolesName = urol.RolesName;
                    typp.Description = urol.Description;
                    typp.UsersIds = urol.UsersIds;
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
            
            var deleteTitle = context.Roles.SingleOrDefault(m => m.Id == id);
            
            if (deleteTitle != null)
            {
                deleteTitle.IsDeleted = true;
                deleteTitle.DeletedDate = DateTime.Now;
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
