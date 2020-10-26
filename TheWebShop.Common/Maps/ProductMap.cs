using System.Linq;
using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models.Commands;
using TheWebShop.Common.Models.Product;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Common.Maps
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<ProductEntity, ProductDto>()
                .ReverseMap()
                .ForMember(model => model.Brand, expression => expression.Ignore());
            
            CreateMap<ProductEntity, ProductWithPicturesDto>()
                .ReverseMap()
                .ForMember(model => model.Brand, expression => expression.Ignore());

            CreateMap<ProductEntity, ProductDetailedDto>()
                .ForMember(model => model.Categories, expression => expression.MapFrom(model => model.Categories.Select(x => x.Category)))
                .ReverseMap();

            CreateMap<ProductEntity, ProductCommand>()
                .ReverseMap();
            
            CreateMap<ProductDto, ProductFormModel>()
                .ForMember(model => model.BrandEntityId, expression => expression.MapFrom(dto => dto.Brand.EntityId))
                .ReverseMap();
        
            CreateMap<ProductEntity, ProductFormModel>()
                .ForMember(model => model.BrandEntityId, expression => expression.MapFrom(dto => dto.BrandEntityId))
                .ReverseMap();
        }
    }
}