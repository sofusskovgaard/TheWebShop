using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Brand;
using TheWebShop.Common.Models;
using TheWebShop.Common.Models.Product;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;

        private readonly IBrandService _brandService;

        private readonly IMapper _mapper;
        
        public SelectList Brands { get; set; }
        
        [BindProperty]
        public IFormFileCollection Pictures { get; set; }
        
        [BindProperty]
        public ProductFormModel FormModel { get; set; }
        
        public CreateModel(IProductService productService, IBrandService brandService, IMapper mapper)
        {
            _productService = productService;
            _brandService = brandService;

            _mapper = mapper;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            var brands = await _brandService.GetByFilter<BrandDto>(new BrandFilter() { PageSize = 0 });
            Brands = new SelectList(brands, nameof(BrandDto.EntityId), nameof(BrandDto.Name));

            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entity = _mapper.Map<ProductEntity>(FormModel);
            
            var product = await _productService.Create<ProductDto>(entity);

            if (Pictures != null)
            {
                var productPictures = new List<ProductPictureDto>();
                
                foreach (var picture in Pictures)
                {
                    await using var stream = new MemoryStream();

                    await picture.CopyToAsync(stream);
                    
                    productPictures.Add(new ProductPictureDto()
                    {
                        Picture = stream.ToArray(),
                        Caption = picture.Name,
                        ContentType = picture.ContentType
                    });
                }

                await _productService.UploadPictures(product.EntityId, productPictures);
            }
            
            return RedirectToPage("/Admin/Products/Index");   
        }
    }
}