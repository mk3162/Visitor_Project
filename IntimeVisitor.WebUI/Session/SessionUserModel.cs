using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntimeVisitor.WebUI.Session
{
    public class SessionUserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone{ get; set; }

        public SessionUserModel()
        {

        }

        public static SessionUserModel CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session[_cookieUserKey] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session[_cookieUserKey] as SessionUserModel;
                }
            }
            set
            {
                if (value is SessionUserModel)
                {
                    SessionUserModel m = value as SessionUserModel;
                    HttpContext.Current.Session[_cookieUserKey] = m;
                }
            }
        }
        private static string _cookieUserKey = "SampleCrm_User";
    }
}