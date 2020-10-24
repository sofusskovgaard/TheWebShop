using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Brand;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Common.Models.Forms;
using TheWebShop.Common.Models.Product;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages.Admin.Brands
{
    public class EditModel : PageModel
    {
        private readonly IBrandService _brandService;

        private readonly IMapper _mapper;

        public BrandDto Brand { get; set; }

        [BindProperty]
        public BrandFormModel FormModel { get; set; }

        public EditModel(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;

            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Brand = await _brandService.GetById<BrandDto>(entityId);

            FormModel = _mapper.Map<BrandFormModel>(Brand);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var brand = await _brandService.UpdateById<BrandDto>(entityId, FormModel);

            return RedirectToPage();
        }
    }
}
