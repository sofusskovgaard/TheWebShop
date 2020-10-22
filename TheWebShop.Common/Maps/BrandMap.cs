using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models.Forms;
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

            CreateMap<BrandDto, BrandFormModel>()
                .ReverseMap();

            CreateMap<BrandEntity, BrandFormModel>()
                .ReverseMap();
        }
    }
}