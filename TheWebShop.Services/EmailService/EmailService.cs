using System.Threading.Tasks;
using Serilog;

namespace TheWebShop.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly ILogger _logger;

        public EmailService(ILogger logger)
        {
            _logger = logger;
        }
        
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await Task.Run(() => _logger.Information("Email: {0}\nSubject: {1}\nMessage: {2}", email, subject, htmlMessage));
        }
    }
}