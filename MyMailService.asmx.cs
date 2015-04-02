using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace SendMailSite
{
    /// <summary>
    /// Summary description for MyMailService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyMailService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string SendMail(string to, string sub, string msg)
        {
            if (to != "" && sub != "" && msg != "")
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress("kailash.pitney@gmail.com");
                mail.Subject = sub;
                string Body = msg;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("kailash.pitney@gmail.com", "kailash@tops123");// Enter seders User name and password
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return "Mail Send Sucessfully";
            }
            else
            {
                return "Something Going Wrong";
            }


        }
    }
}
