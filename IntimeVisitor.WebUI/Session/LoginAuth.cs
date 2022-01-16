using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Session
{
    public class LoginAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionUserModel.CurrentUser == null)
            {
                Controller controller = filterContext.Controller as Controller;
                string retUrl = HttpContext.Current.Request.Url.PathAndQuery;
                HttpContext.Current.Session["retUrl"] = retUrl;
                filterContext.Result = new RedirectResult("/Login/LoginOpen");
                return;
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}