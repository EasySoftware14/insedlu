using System.Configuration;
using Insedlu.Implementation;

namespace Insendu.Services.Handlers
{
    public class EmailHandler
    {
        private readonly EmailService _emailService;

        public EmailHandler()
        {
            _emailService = new EmailService();
        }

        public void ProcessEmail(string email, string pass)
        {
            var appConfig = ConfigurationManager.AppSettings["email_templates_path"];

            var siteUrl = ConfigurationManager.AppSettings["website_url"];
            var footerImage = string.Format("{0}Images/insedluLog.png", siteUrl);

            var path = string.Format("{0}club_setup.txt", appConfig);
            var template = new TokenTemplate(path);
            template.SetTokenValue("CLUBADMIN", "");
            template.SetTokenValue("CLUBNAME", "");
            template.SetTokenValue("DATE", "");
            template.SetTokenValue("FOOTERIMAGE", "");
            template.SetTokenValue("ADMINEMAIL", "");
          

        }
    }
}
