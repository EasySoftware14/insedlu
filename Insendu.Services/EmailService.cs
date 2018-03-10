﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Insedlu.Implementation;

namespace Insendu.Services
{
    public class EmailService
    {
        public void SendEmail(string emailAddress, string tempPass, string path, string name)
        {
            var pass = ConfigurationManager.AppSettings["EmailPassword"];
            var webUrl = ConfigurationManager.AppSettings["website_url"];

            var template = SetUp(tempPass, path, name);
         
            var sender = ConfigurationManager.AppSettings["sender"];
            var mail = new MailMessage(sender, emailAddress);

            mail.To.Add(emailAddress);
            mail.From = new MailAddress(sender, "Insedlu Administrator");
            mail.Subject = "User Registration";
            mail.Body = template;
           // mail.Body = string.Format("Please be advised that you have been added as a user to Insedlu System Website. Click here {0} <br/> to reset your password", link);
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;
               
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(sender, pass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);
                
            }

        }
        public void SendEmail(string emailAddress, string tempPass)
        {
            var pass = ConfigurationManager.AppSettings["EmailPassword"];
            var webUrl = ConfigurationManager.AppSettings["website_url"];
            var siteUrl = ConfigurationManager.AppSettings["live_website_url"];
            var sender = "ayandapatrick@gmail.com";
            var mail = new MailMessage(sender, emailAddress);
            var link = string.Format("<a href='{0}resetpassword.aspx?temppass={1}'>Reset</a>", siteUrl, tempPass);
            mail.To.Add(emailAddress);
            mail.From = new MailAddress(sender, "Insedlu Administrator");
            mail.Subject = "User Registration";
            mail.Body = string.Format("Please be advised that you have been added as a user to Insedlu System Website. Click here {0} <br/> to reset your password", link);
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(sender, pass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);

            }

        }
        private string SetUp(string tempPass, string tempPath, string name)
        {
            var appConfig = ConfigurationManager.AppSettings["email_templates_path"];

            var siteUrl = ConfigurationManager.AppSettings["live_website_url"];
            var footerImage = string.Format("{0}Images/insedluLog.png", siteUrl);
            var link = string.Format("<a href={0}resetpassword.aspx?temppass={1}>create</a>", siteUrl, tempPass);
            var path = string.Format("{0}emailtemplate.txt", appConfig);
            var template = string.Empty;

            using (var reader = new StreamReader(tempPath))
            {
                template = reader.ReadToEnd();
            }

            template = template.Replace("{USERNAME}", name);
            template = template.Replace("{LINK}", link);
            template = template.Replace("{DATE}", DateTime.Now.Date.ToShortDateString());
            template = template.Replace("{FOOTERIMAGE}", footerImage);

            return template;
        }

        public void SendTaskNotificationEmail(string emailAddress, string taskDescription)
        {
            var pass = ConfigurationManager.AppSettings["EmailPassword"];
            var sender = ConfigurationManager.AppSettings["sender"]; ;
            var mail = new MailMessage(sender, emailAddress);
            var siteUrl = ConfigurationManager.AppSettings["live_website_url"];
            var footerImage = string.Format("{0}Images/insedluLog.png", siteUrl);

            var body = GetNotificationBody(taskDescription);

            mail.To.Add(emailAddress);
            mail.From = new MailAddress(sender, "Insedlu Administrator");
            mail.Subject = "User Registration";
            mail.Body = body;

            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(sender, pass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);

            }
        }

        private string GetNotificationBody(string taskDescription)
        {
            var body = string.Empty;


            return body;
        }
    }
}
