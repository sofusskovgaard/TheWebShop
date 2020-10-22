using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWebShop.Data;

namespace TheWebShop.WebApp.Pages.Admin
{
    public class SeedDatabaseModel : PageModel
    {
        private readonly DatabaseContext _databaseContext;

        public SeedDatabaseModel(IDatabaseContextFactory databaseContextFactory)
        {
            _databaseContext = databaseContextFactory.CreateDbContext(null);
        }
        
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _databaseContext.Database.EnsureDeletedAsync();
            await _databaseContext.Database.EnsureCreatedAsync();

            return RedirectToPage("/Admin/Index");
        }
    }
}