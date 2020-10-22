using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TheWebShop.Common.Dtos;
using TheWebShop.Services.EntityServices.BrandService;

namespace TheWebShop.WebApp.Pages.Admin.Brands
{
    public class DeleteModel : PageModel
    {
        private readonly IBrandService _brandService;

        public BrandDto Brand { get; set; }

        public DeleteModel(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Brand = await _brandService.GetById<BrandDto>(entityId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            await _brandService.DeleteById(entityId);
            return RedirectToPage("Index");
        }
    }
}
