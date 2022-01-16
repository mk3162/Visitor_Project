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
    public class TitleController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        TitleManager titleManager = new TitleManager(new TitleDAL());
        // GET: Title
        public ActionResult Title()
        {
            var TitleList = titleManager.GetAllAsList();
            return View(TitleList);
        }
        [HttpPost]
        public ActionResult TitleAdd(Title titleadd)
        {
            try
            {
                titleManager.Add(titleadd);


            }
            catch (Exception)
            {

                return RedirectToAction("Title");
            }
            return RedirectToAction("Title");
        }


       
        public ActionResult SoftDelete(Guid id)
        {
            titleManager.Delete(id);
            return RedirectToAction("Title");
        }


        //public ActionResult Update(Guid id)
        //{
        //    var deleteTitle = context.Titles.SingleOrDefault(m => m.Id == id);
        //    deleteTitle.IsDeleted = true;
        //    //context.Titles.Remove(deleteTitle);

        //    context.SaveChanges();
        //    return RedirectToAction("Title");
        //}
        //public ActionResult Update(int? Titleid)
        //{
        //    var kayit = context.Titles.Where(k => k.Id == Titleid).SingleOrDefault();
        //    Title model = new Entities.Domain.Title()
        //    {
        //        Id = kayit.Id,
        //        TitleName = kayit.Name,
        //        Description = kayit.Desc,
        //        yas = kayit.yas
        //    };
        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult kayitDuzenle(kayitModel m)
        //{
        //    Kayitlar kayit = db.Kayitlar.Where(k => k.kayitId == m.kayitId).SingleOrDefault();
        //    kayit.adsoyad = m.adsoyad;
        //    kayit.mail = m.mail;
        //    kayit.yas = m.yas;
        //    db.SaveChanges();
        //    ViewBag.sonuc = "Kayıt Güncelle";
        //    return View();
        //}

    }
}