using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models.Product;
using TheWebShop.Data.Entities;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Common.Maps
{
    public class BaseMap : Profile
    {
        public BaseMap()
        {
//            CreateMap<BaseDto, BaseEntity>()
//                .IncludeAllDerived()
//                .ForMember(model => model.CreatedAt, expression => expression.Ignore())
//                .ForMember(model => model.UpdatedAt, expression => expression.Ignore());
//            
//            CreateMap<BaseFormModel, BaseEntity>()
//                .IncludeAllDerived()
//                .ForMember(model => model.CreatedAt, expression => expression.Ignore())
//                .ForMember(model => model.UpdatedAt, expression => expression.Ignore());
        }
    }
}