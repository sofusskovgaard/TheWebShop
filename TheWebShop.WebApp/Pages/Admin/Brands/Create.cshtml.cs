using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Brand;
using TheWebShop.Common.Models.Forms;
using TheWebShop.Data.Entities.Brand;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Services.EntityServices.BrandService;

namespace TheWebShop.WebApp.Pages.Admin.Brands
{
    public class CreateModel : PageModel
    {
        private readonly IBrandService _brandService;

        private readonly IMapper _mapper;

       [BindProperty]
        public BrandFormModel FormModel { get; set; }

        public CreateModel(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;

            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entity = _mapper.Map<BrandEntity>(FormModel);

            await _brandService.Create<BrandDto>(entity);

            return RedirectToPage("Index");
        }
    }
}
