using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace IntimeVisitor.WebUI.Extension
{
    public class Helper
    {
        public static void MailGonder(string Mesaj, string mail)
        {
            IPAddress[] IP = Dns.GetHostAddresses(Dns .GetHostName());

            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("noreply@onlinetelekom.com.tr");
            mesaj.Subject = "Bilgi | Intime Info Visitor ";
            mesaj.BodyEncoding = System.Text.Encoding.UTF8;
            mesaj.Body = Mesaj;
            mesaj.IsBodyHtml = true;
            mesaj.Priority = MailPriority.High;
            SmtpClient clie = new SmtpClient("mail.onlinetelekom.com.tr");
            clie.UseDefaultCredentials = true;
            clie.Port = 587;
            clie.Credentials = new NetworkCredential("noreply@onlinetelekom.com.tr", "onl*1412");

            mesaj.To.Add(mail);
            //mesaj.To.Add("arda.parlak@intimeinfo.com.tr");
            //mesaj.To.Add("nsrin.yldrm@gmail.com");
            try 
            { 
                clie.Send(mesaj); 
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
    }
}