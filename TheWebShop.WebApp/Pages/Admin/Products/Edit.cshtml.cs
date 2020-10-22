using System;
using System.Collections.Generic;
using System.Dynamic;
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
using TheWebShop.Common.Models;
using TheWebShop.Common.Models.Product;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Services.DataAccessServices.Brand;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;

        private readonly IBrandService _brandService;

        private readonly IMapper _mapper;
        
        public ProductDto Product { get; set; }
        
        public IEnumerable<ProductPictureDto> ProductPictures { get; set; }
        
        public SelectList Brands { get; set; }
        
        [BindProperty]
        public IFormFileCollection Pictures { get; set; }
        
        [BindProperty]
        public ProductFormModel FormModel { get; set; }

        public EditModel(IProductService productService, IBrandService brandService, IMapper mapper)
        {
            _productService = productService;
            _brandService = brandService;

            _mapper = mapper;
        }
        
        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Product = await _productService.GetById<ProductDto>(entityId);
            ProductPictures = await _productService.GetPicturesForProduct(entityId);
            
            var brands = await _brandService.GetByFilter<BrandDto>(new BrandFilter() { PageSize = 0 });
            Brands = new SelectList(brands, nameof(BrandDto.EntityId), nameof(BrandDto.Name), brands.FirstOrDefault(x => x.EntityId == Product.Brand.EntityId));

            FormModel = _mapper.Map<ProductFormModel>(Product);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = await _productService.UpdateById<ProductDto>(entityId, FormModel);
            
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
            
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemovePicture([FromRoute] int entityId, int pictureId)
        {
            await _productService.DeletePictureById(pictureId);
            return RedirectToPage();
        }
    }
}