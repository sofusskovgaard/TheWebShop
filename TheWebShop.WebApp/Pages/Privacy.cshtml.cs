using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace TheWebShop.WebApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger _logger;

        public PrivacyModel(ILogger logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
