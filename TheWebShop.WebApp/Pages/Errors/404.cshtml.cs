using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace TheWebShop.WebApp.Pages.Errors
{
    public class NotFoundModel : PageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger _logger;

        public NotFoundModel(ILogger logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}