using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public ProductDetailedDto Product { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Quantity { get; set; } = 1;

        public DetailsModel(IProductService productService, IMapper mapper)
        {
            _productService = productService;

            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync([FromRoute] int entityId)
        {
            Product = await _productService.GetById<ProductDetailedDto>(entityId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromRoute] int entityId)
        {
            return await Task.Run(
                       () =>
                       {
                           var basketCookie = Request.Cookies["BASKET"];
                           var basket = new Common.Models.BasketModel();

                           if (basketCookie != null) basket =
                               JsonConvert.DeserializeObject<Common.Models.BasketModel>(basketCookie);

                           var basketSearch = basket.Items.FirstOrDefault(x => x.ProductEntityId == entityId);

                           if (basketSearch != null)
                           {
                               basketSearch.Quantity += Quantity;
                           }
                           else
                           {
                               basket.Items.Add(new BasketItemModel() { ProductEntityId = entityId, Quantity = Quantity });
                           }

                           Response.Cookies.Append("BASKET", JsonConvert.SerializeObject(basket));

                           return RedirectToPage(new {entityId});
                       }
                   );
        }
    }
}