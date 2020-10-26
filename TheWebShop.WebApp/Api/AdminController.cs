using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TheWebShop.Data;
using TheWebShop.Data.Entities.Role;
using TheWebShop.Data.Entities.User;

namespace TheWebShop.WebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DatabaseContext _context;

        private readonly SignInManager<UserEntity> _signInManager;

        private readonly UserManager<UserEntity> _userManager;

        public AdminController(DatabaseContext context, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("SeedDatabase")]
        public async Task<IActionResult> SeedDatabase()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

            return Ok("Successfully seeded the database");
        }

        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var store = new RoleStore<RoleEntity, DatabaseContext, int>(_context);
            return Ok(await store.Roles.ToListAsync());
        }

        [HttpGet("CreateRole/{name}")]
        public async Task<IActionResult> CreateRole(string name)
        {
            var store = new RoleStore<RoleEntity, DatabaseContext, int>(_context);
            var role = await store.CreateAsync(new RoleEntity() {Name = name, NormalizedName = name.ToUpper()});

            await _context.SaveChangesAsync();
            return Ok(role);
        }

        [HttpGet("AssignRole/{role}")]
        public async Task<IActionResult> AssignRole(string role)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var result = await _userManager.AddToRoleAsync(await _userManager.GetUserAsync(User), role);

                return Ok(result);
            }

            return BadRequest();
        }
    }
}