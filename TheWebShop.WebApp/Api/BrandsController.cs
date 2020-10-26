using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Brand;
using TheWebShop.Services.EntityServices.BrandService;

namespace TheWebShop.WebApp.Api
{
    [Route("api/[controller]")]
    public class BrandsController : BaseApiController<BrandFilter>
    {
        private readonly IBrandService _brandService;

        public BrandsController(
            IBrandService brandService)
        {
            _brandService = brandService;
        }
        
        [HttpGet]
        public override async Task<IActionResult> GetByFilter([FromQuery] BrandFilter filter)
        {
            return await this.TryAsync(async () =>
            {
                var count = await _brandService.CountEntitiesByFilter(filter);
                Response.Headers.Add("X-Total-Items", count.ToString());
                
                return Ok(await _brandService.GetByFilter<BrandDto>(filter));
            });
        }

        [HttpGet("{entityId}")]
        public override async Task<IActionResult> GetById(int entityId)
        {
            return await this.TryAsync(async () => Ok(await _brandService.GetById<BrandDto>(entityId)));
        }

        [HttpDelete("{entityId}")]
        public override async Task<IActionResult> DeleteById(int entityId)
        {
            return await this.TryAsync(async () => Ok(await _brandService.DeleteById(entityId)));
        }
    }
}