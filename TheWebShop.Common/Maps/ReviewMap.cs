using AutoMapper;
using TheWebShop.Common.Dtos;
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
        }
    }
}