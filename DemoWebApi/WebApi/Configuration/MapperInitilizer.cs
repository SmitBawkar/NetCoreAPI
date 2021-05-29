using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO;

namespace WebApi.Configuration
{
    public class MapperInitilizer: Profile
    {
        public MapperInitilizer()
        {
            CreateMap<IdentityUser, UserDto>().ReverseMap();
        }
    }
}
