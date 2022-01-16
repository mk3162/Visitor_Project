using IntimeVisitor.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntimeVisitor.WebAPI.Controllers
{
    //[Authorize]
    public class NotesController : ApiController
    {
        IntimeVisitorContext context = new IntimeVisitorContext();

        [HttpGet]
        public IHttpActionResult Index()
        {
            var NotesList = context.Notes.ToList();
            return Ok(NotesList);
        }
    }
}
