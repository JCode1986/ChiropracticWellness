using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models.Services
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _iconfiguration;

        public EmailSender(IConfiguration Configuration)
        {
            _iconfiguration = Configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_iconfiguration["SENDGRID_API_KEY"]);
            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("admin@wellnesschiropractic.com", "Site Admin");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);

        }
    }
}
