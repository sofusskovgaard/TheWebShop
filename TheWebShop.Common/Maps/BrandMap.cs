using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Data.Entities.Brand;

namespace TheWebShop.Common.Maps
{
    public class BrandMap : Profile
    {
        public BrandMap()
        {
            CreateMap<BrandEntity, BrandDto>()
                .ReverseMap();

            CreateMap<BrandEntity, BrandDetailedDto>()
                .ReverseMap();
        }
    }
}