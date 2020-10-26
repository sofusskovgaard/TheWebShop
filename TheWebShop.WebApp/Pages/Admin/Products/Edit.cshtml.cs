using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IMapper _mapper;
        
        public ProductDto Product { get; set; }
        
        public IEnumerable<ProductPictureDto> ProductPictures { get; set; }
        
        public SelectList Brands { get; set; }
        
        [BindProperty]
        public IFormFileCollection Pictures { get; set; }
        
        [BindProperty]
        public ProductFormModel FormModel { get; set; }

        public EditModel(IProductService productService, IBrandService brandService, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _productService = productService;
            _brandService = brandService;

            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Product = await _productService.GetById<ProductDto>(entityId);
            ProductPictures = await _productService.GetPicturesForProduct(entityId);
            
            var brands = await _brandService.GetByFilter<BrandDto>(new BrandFilter() { PageSize = 0 });
            Brands = new SelectList(brands, nameof(BrandDto.EntityId), nameof(BrandDto.Name), Product.Brand != null ? brands.FirstOrDefault(x => x.EntityId == Product.Brand.EntityId) : null);

            FormModel = _mapper.Map<ProductFormModel>(Product);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            if (!ModelState.IsValid)
            {
                return await OnGetAsync(entityId);
            }

            var product = await _productService.UpdateById<ProductDto>(entityId, FormModel);
            
            if (Pictures != null)
            {
                var productPictures = new List<ProductPictureDto>();
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                
                foreach (var picture in Pictures)
                {
                    var uniqueName = $"{DateTime.Now.ToFileTimeUtc()}-{Guid.NewGuid()}".ToUpper();
                    var filename = $"{uniqueName}.{picture.FileName.Split(".").Last()}";
                    var filePath = Path.Combine(uploadsFolder, filename);
                    await using var fileStream = new FileStream(filePath, FileMode.Create);

                    await picture.CopyToAsync(fileStream);

                    productPictures.Add(new ProductPictureDto()
                    {
                        Picture = filename,
                        Caption = picture.Name
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