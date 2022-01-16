using IntimeVisitor.Bussiness.Concrete;
using IntimeVisitor.DataAccess.Concrete;
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
    public class BranchTypeController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        BranchTypeManager branchTypeManager = new BranchTypeManager(new BranchTypeDAL());
        // GET: BranchType
        public ActionResult BranchType()
        {
            //var BranchTypeList = context.BranchTypes.Where(v=>v.IsDeleted==false).ToList();
            var BranchTypeList = branchTypeManager.GetAllAsList();
            return View(BranchTypeList);
        }

        public ActionResult GetBranchType(Guid id)
        {
            //var brctype = context.BranchTypes.Find(id);
            var brctype = branchTypeManager.Get(id);
            return View("GetBranchType", brctype);
        }

        public ActionResult StatusUpdate(BranchType branchType)
        {
            //var Comtypp = context.BranchTypes.Find(branchType.Id);
            var Comtypp = branchTypeManager.Get(branchType.Id);
            if (Comtypp.Status == true)
            {
                Comtypp.Status = false;
                branchTypeManager.Update(Comtypp);
            }
            else
            {
                Comtypp.Status = true;
                branchTypeManager.Update(Comtypp);
            }


            return RedirectToAction("BranchType");
        }
        public ActionResult UpdateBranchType(BranchType BrcType)
        {
            //var Comtypp = context.BranchTypes.Find(BrcType.Id);
            //Comtypp.BranchTypeName = BrcType.BranchTypeName;
            //Comtypp.Status = BrcType.Status;

            //context.SaveChanges();

            branchTypeManager.Update(BrcType);
            return RedirectToAction("BranchType");
        }


        public ActionResult BranchTypeAdd(BranchType branchType)
        {
            try
            {
                //context.BranchTypes.Add(branchType);
                //branchType.Status = true;
                //branchType.IsDeleted = false;
                //context.SaveChanges();
                branchTypeManager.Add(branchType);

            }
            catch (Exception)
            {
                return RedirectToAction("BranchType");

            }
            return RedirectToAction("BranchType");
        }

        public ActionResult SoftDelete(Guid id)
        {
            //var deleteBr = context.BranchTypes.SingleOrDefault(m => m.Id == id);
            //deleteBr.IsDeleted = true;
            //deleteBr.DeletedDate = DateTime.Now;
            ////context.Titles.Remove(deleteTitle);

            //context.SaveChanges();
            branchTypeManager.Delete(id);
            return RedirectToAction("BranchType");
        }
    }
}