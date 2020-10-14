using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using TheWebShop.Data.Entities;

namespace TheWebShop.WebApp.ViewComponents
{
    public class EntityTableViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<IBaseEntity> entities)
        {
            return await Task.Run(() => View(entities));
        }
    }
}