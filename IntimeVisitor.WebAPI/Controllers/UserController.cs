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
    public class UserController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        [HttpGet]

        public IHttpActionResult Index()
        {
            var UserList = context.Users.Where(x => x.IsDeleted == false).ToList();
            return Ok(UserList);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] User userAdd)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(userAdd);
                userAdd.IsDeleted = false;
                userAdd.Status = true;

                context.SaveChanges();


                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
        [HttpPut]
        public IHttpActionResult Edit(Guid id, [FromBody] User userU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                
                var u = context.Users.Find(id);
                


                if (u != null)
                {
                    u.Name = userU.UserName;
                    u.SurName = userU.SurName;
                    u.RegisterNo = userU.RegisterNo;
                    u.TCNo = userU.TCNo;
                    u.FatherName = userU.FatherName;
                    u.MotherName = userU.MotherName;
                    u.Gender = userU.Gender;
                    u.BirthPlace = userU.BirthPlace;
                    u.BirthDate = userU.BirthDate;
                    u.Address = userU.Address;
                    u.EPosta = userU.EPosta;
                    u.EPostaKep = userU.EPostaKep;
                    u.Phone = userU.Phone;
                    u.Password = userU.Password;
                    u.UserTypeId = userU.UserTypeId;
                    u.UserName = userU.UserName;
                    u.Password = userU.Password;
                    u.Status = userU.Status;
                    u.DepartmentId = userU.DepartmentId;
                    u.IsActive = userU.IsActive;
                    u.Code = userU.Code;
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
            
            var deleteBr = context.Users.SingleOrDefault(m => m.Id == id);
            
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
