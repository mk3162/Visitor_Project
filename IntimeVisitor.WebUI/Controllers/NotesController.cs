using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
    //[LoginAuth]

    public class NotesController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        // GET: Notes
        public ActionResult Notes()
        {
            var NotesList = context.Notes.ToList();
            return View(NotesList);
        }

        //[HttpPost]
        //public ActionResult NotesAdd(Notes notes)
        //{
        //    context.Notes.Add(notes);
        //    context.SaveChanges();
        //    return RedirectToAction("Notes");
        //}
    }
}