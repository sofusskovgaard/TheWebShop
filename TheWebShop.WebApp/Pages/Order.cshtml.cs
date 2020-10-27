using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TheWebShop.Common.Dtos;
using TheWebShop.Services.EntityServices.OrderService;

namespace TheWebShop.WebApp.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IOrderService _orderService;

        public OrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty(SupportsGet = true)]
        public int OrderId { get; set; }

        [BindProperty]
        public OrderDto Order { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Order = await _orderService.GetById<OrderDto>(OrderId);
            return Page();
        }
    }
}
