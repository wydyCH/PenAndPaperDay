using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PenAndPaperDay.Core.Configuration;
using PenAndPaperDay.Core.Interfaces.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PenAndPaperDay.Core.Mailing
{
    public class SendGridEmailSender : IEmailSenderService
    {
        private readonly IOptions<PenAndPaperConfiguration> _penAndPaperConfiguration;
        private readonly ILogger _logger;

        public SendGridEmailSender(IOptions<PenAndPaperConfiguration> penAndPaperConfiguration, ILogger<SendGridEmailSender> logger)
        {
            _logger = logger;
            _penAndPaperConfiguration = penAndPaperConfiguration;
        }

        public bool SendMail(IList<string> to, string subject, string body)
        {
            return Send(to, subject, body).Result;            
        }

        private async Task<bool> Send(IList<string> tos, string subject, string body)
        {
            try
            {
                var apiKey = _penAndPaperConfiguration.Value.SendGridAPIKey;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_penAndPaperConfiguration.Value.EmailSender, _penAndPaperConfiguration.Value.EmailSenderName);


                List<EmailAddress> recipients = new List<EmailAddress>();
                foreach (var to in tos)
                {
                    var recipient = new EmailAddress(to);
                    recipients.Add(recipient);
                }

                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, recipients, subject, "", body, false);
                var response = await client.SendEmailAsync(msg);

                var validStati = new List<HttpStatusCode>()
                {
                    HttpStatusCode.OK,
                    HttpStatusCode.Created,
                    HttpStatusCode.Accepted
                };

                _logger.LogInformation(response.StatusCode.ToString());

                return validStati.Contains(response.StatusCode);                
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, "Error Sending Mail");
            }

            return false;
        }
    }
}
