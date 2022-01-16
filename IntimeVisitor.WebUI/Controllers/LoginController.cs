using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.WebUI.Extension;
using IntimeVisitor.WebUI.Session;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace IntimeVisitor.WebUI.Controllers
{
    public class LoginController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        // GET: Login
        public ActionResult Index()
        {
            List<SelectListItem> UserTypes =

             context.UserTypes.Where(a => a.UserTypeName == "ZİYARETÇİ").Select(i => new SelectListItem
             {
                 Text = i.UserTypeName,
                 Value = i.Id.ToString()
             }).ToList();


            ViewBag.types = UserTypes;
            return View();
        }
        public ActionResult LoginOpen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VisitorVisitAdd(Visit visitAdd, VisitDetail visitDetail)
        {
            return RedirectToAction("VisitorVisitAdd");
        }


        [HttpPost]
        public ActionResult RegisterAdd(User user)
        {
            var log = context.Users.FirstOrDefault(x => x.EPosta == user.EPosta);
            if (log == null)
            {
                user.Status = true;
                user.IsDeleted = false;
                user.IsActive = true;
                user.Password = Membership.GeneratePassword(6, 1);
                context.Users.Add(user);

                context.SaveChanges();

                string Mesaj = "<br>" +
                    "Intime Visitor Giriş Eposta: " + user.EPosta + 
                    "<br>" +
                    "Intime Visitor Giriş Şifre : " + user.Password
                    ;


                Helper.MailGonder(Mesaj, user.EPosta); // Mesaj metni hazırla
                return RedirectToAction("LoginOpen");
            }
            else
            {
                ViewBag.RegisterError = "Girmiş oldugunuz mail adresi sistemde kayıtlı";
                return RedirectToAction("Index");
            }



        }
        public ActionResult ForgotPassword()

        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(User us)
        {
            var log = context.Users.FirstOrDefault(x => x.EPosta == us.EPosta);
            if (log != null)
            {
                us.Status = true;
                us.IsDeleted = false;
                us.IsActive = true;
                us.Password = Membership.GeneratePassword(6, 1);
                log.Password = us.Password;
                context.SaveChanges();
                string Mesaj = "<br>" +
                    "Intime Visitor Giriş Eposta: " + us.EPosta +
                    "<br>" +
                    "Intime Visitor Giriş Şifre : " + us.Password
                    ;


                Helper.MailGonder(Mesaj, us.EPosta); // Mesaj metni hazırla
                return RedirectToAction("LoginOpen");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult LoginOpen(User us)
        {

            var log = context.Users.FirstOrDefault(x => x.EPosta == us.EPosta && x.Password == us.Password);

            if (log != null)
            {
                SessionUserModel.CurrentUser = new SessionUserModel { Id = log.Id, Name = log.Name, Phone = log.Phone, Surname = log.SurName, Email = log.EPosta };
                ViewBag.Login = "Giriş Başarılı Yönlendiriliyorsunuz ";
                FormsAuthentication.SetAuthCookie(log.EPosta, false);

                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                ViewBag.LoginError = "Hatalı Bilgi Girişi Yaptınız,Tekrardan Deneyiniz";
                return View();
            }


        }
        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();
            HttpContext.Session.Clear();
            return RedirectToAction("LoginOpen");
        }


    }
}