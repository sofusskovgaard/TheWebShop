using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Data.Entities.ProductPicture;

namespace TheWebShop.Common.Maps
{
    public class ProductPictureMap : Profile
    {
        public ProductPictureMap()
        {
            CreateMap<ProductPictureEntity, ProductPictureDto>()
                .ReverseMap();

            CreateMap<ProductPictureEntity, ProductPictureDetailedDto>()
                .ReverseMap();
        }
    }
}