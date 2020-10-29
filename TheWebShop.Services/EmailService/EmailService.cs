using System.IO;
using System.Net;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;

namespace TheWebShop.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly ILogger _logger;
        
        private const string senderMail = "no-reply@mysuperduperlongdomainformysuperduperawesomeschoolproject.com";
        private const string apiKey = "";

        public EmailService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
//            var client = new SendGridClient(apiKey);
//            var from = new EmailAddress(senderMail, "no-reply");
//            var to = new EmailAddress(email);
//            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
//            
//            await client.SendEmailAsync(msg);
            
            _logger.Information("Sent an email to \"{0}\" with the subject of \"{1}\" and an htmlMessage of \"{2}\"", email, subject, htmlMessage);
        }
    }
}