using HR.LeaveManagement.Application.Model;
using HR.LeaveManagement.Application.Persistence.Infrastructure;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSettings { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client  = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress 
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted;

        }
    }
}
