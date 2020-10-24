using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Models.Forms;
using TheWebShop.Data.Entities.Review;

namespace TheWebShop.Common.Maps
{
    public class ReviewMap : Profile
    {
        public ReviewMap()
        {
            CreateMap<ReviewEntity, ReviewDto>()
                .ReverseMap();

            CreateMap<ReviewEntity, ReviewDetailedDto>()
                .ReverseMap();

            CreateMap<ReviewDto, ReviewFormModel>()
                .ReverseMap();

            CreateMap<ReviewEntity, ReviewFormModel>()
                .ReverseMap();
        }
    }
}