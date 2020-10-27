using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace TheWebShop.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }
        
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await Task.Run(() => _logger.LogInformation("Email: {0}\nSubject: {1}\nMessage: {3}", email, subject, htmlMessage));
        }
    }
}