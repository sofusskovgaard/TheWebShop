using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Common.Models.Commands;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Api
{
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController<ProductFilter>
    {
        private readonly IProductService _productService;

        public ProductsController(
            IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public override async Task<IActionResult> GetByFilter([FromQuery] ProductFilter filter)
        {
            return await this.TryAsync(async () =>
            {
                var count = await _productService.CountEntitiesByFilter(filter);
                Response.Headers.Add("X-Total-Items", count.ToString());
                
                return Ok(await _productService.GetByFilter<ProductDetailedDto>(filter));
            });
        }

        [HttpGet("{entityId}")]
        public override async Task<IActionResult> GetById(int entityId)
        {
            return await this.TryAsync(async () => Ok(await _productService.GetById<ProductDetailedDto>(entityId)));
        }

        [HttpDelete("{entityId}")]
        public override async Task<IActionResult> DeleteById(int entityId)
        {
            return await this.TryAsync(async () => Ok(await _productService.DeleteById(entityId)));
        }
    }
}