using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Entities.User, Models.UserDto>();
            CreateMap<Models.UserForCreationDto, Entities.User>();
            CreateMap<Models.UserForUpdateDto,Entities.User>();
            CreateMap<Entities.User, Models.UserForUpdateDto>();
        }        
    }
}
