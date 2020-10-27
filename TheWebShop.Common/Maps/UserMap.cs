using System;
using System.Collections.Generic;
using System.Text;

using AutoMapper;

using TheWebShop.Common.Dtos;
using TheWebShop.Data.Entities.User;

namespace TheWebShop.Common.Maps
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<UserEntity, UserDto>()
                .ReverseMap();
        }
    }
}
