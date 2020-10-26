using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using TheWebShop.Services.CachingServices;

namespace TheWebShop.WebApp.Api
{
    [Route("api/[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly ICachingService _cachingService;

        public CacheController(ICachingService cachingService)
        {
            _cachingService = cachingService;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetKey(string key)
        {
            return Ok(await _cachingService.Get("cache", key));
        }

        [HttpGet("{key}/{value}")]
        public async Task<IActionResult> SetKey(string key, string value)
        {
            return Ok(await _cachingService.Set(value, "cache", key));
        }
    }
}