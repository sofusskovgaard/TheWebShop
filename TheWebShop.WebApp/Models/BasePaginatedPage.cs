using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheWebShop.WebApp.Models
{
    public abstract class BasePaginatedPage : BasePage
    {
        public int TotalResults { get; set; }

        [BindProperty(SupportsGet = true)]
        public int p { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int ps { get; set; } = 10;
        
        public Dictionary<string, string> preexistingFilters { get; set; } = new Dictionary<string, string>();

        protected BasePaginatedPage()
        {
        }

        public void SetPreexistingFilters()
        {
            preexistingFilters = Request.Query.ToDictionary(pair => pair.Key, pair => pair.Value.ToString());
        }
    }
}
