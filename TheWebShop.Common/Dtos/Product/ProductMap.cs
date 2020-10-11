using System;
using System.Collections.Generic;
using System.Text;

using AutoMapper;

using TheWebShop.Common.Dtos.Brand;
using TheWebShop.Data.Entities.Brand;

namespace TheWebShop.Common.Dtos.Product
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<BrandEntity, BrandDto>()
                .ReverseMap();

            CreateMap<BrandEntity, BrandDetailedDto>()
                .ReverseMap();
        }
    }
}
