using System.Linq;
using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models.Forms;
using TheWebShop.Data.Entities.Category;

namespace TheWebShop.Common.Maps
{
    public class CategoryMap : Profile
    {
        public CategoryMap()
        {
            CreateMap<CategoryEntity, CategoryDto>()
                .ReverseMap();
            
            CreateMap<CategoryEntity, CategoryDetailedDto>()
                .ReverseMap();

            CreateMap<CategoryDto, CategoryFormModel>()
                .ReverseMap();

            CreateMap<CategoryEntity, CategoryFormModel>()
                .ReverseMap();
        }
    }
}