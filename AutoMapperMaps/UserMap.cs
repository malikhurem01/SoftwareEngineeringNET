using AutoMapper;
using ResumeMaker.API.DTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.AutoMapperMaps
{
    public class UserMap : Profile
    {
        public UserMap() {
            CreateMap<User, GetUserDto>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<RegisterUserDto, UserLoginDto>();
        }
    }
}
