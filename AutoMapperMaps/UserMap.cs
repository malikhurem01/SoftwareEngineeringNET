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
            CreateMap<User, GetUserInfoDto>()
                .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.Education))
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experiences))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages));
        }
    }
}
