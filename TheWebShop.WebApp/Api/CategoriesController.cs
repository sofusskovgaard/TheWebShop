using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Services.EntityServices.CategoryService;

namespace TheWebShop.WebApp.Api
{
    [Route("api/[controller]")]
    public class CategoriesController : BaseApiController<CategoryFilter>
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public override async Task<IActionResult> GetByFilter([FromQuery] CategoryFilter filter)
        {
            return await this.TryAsync(async () =>
            {
                var count = await _categoryService.CountEntitiesByFilter(filter);
                Response.Headers.Add("X-Total-Items", count.ToString());
                
                return Ok(await _categoryService.GetByFilter<CategoryDto>(filter));
            });
        }

        [HttpGet("{entityId}")]
        public override async Task<IActionResult> GetById(int entityId)
        {
            return await this.TryAsync(async () => Ok(await _categoryService.GetById<CategoryDto>(entityId)));
        }

        [HttpDelete("{entityId}")]
        public override async Task<IActionResult> DeleteById(int entityId)
        {
            return await this.TryAsync(async () => Ok(await _categoryService.DeleteById(entityId)));
        }
    }
}