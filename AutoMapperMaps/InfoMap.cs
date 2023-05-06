using AutoMapper;
using ResumeMaker.API.DTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.AutoMapperMaps
{
    public class InfoMap : Profile
    {
        public InfoMap()
        {
            CreateMap<User, AddInformationDto>();
            CreateMap<AddInformationDto, User>();

            CreateMap<AddEducationDto, Education>();
            CreateMap<GetEducationDto, AddEducationDto>();
            CreateMap<GetEducationDto, Education>();
            CreateMap<AddEducationDto, GetEducationDto>();

            CreateMap<AddExperienceDto, Experience>();
            CreateMap<GetExperienceDto, AddExperienceDto>();
            CreateMap<GetExperienceDto, Experience>();
            CreateMap<AddExperienceDto, GetExperienceDto>();

            CreateMap<AddSkillDto, Skill>();
            CreateMap<GetSkillDto, AddSkillDto>();
            CreateMap<GetSkillDto, Skill>();
            CreateMap<AddSkillDto, GetSkillDto>();

            CreateMap<AddLanguageDto, Language>();
            CreateMap<GetLanguageDto, AddLanguageDto>();
            CreateMap<GetLanguageDto, Language>();
            CreateMap<AddLanguageDto, GetLanguageDto>();

            CreateMap<AddCardDto, Card>();
            CreateMap<GetCardDto, AddCardDto>();
            CreateMap<GetCardDto, Card>();
            CreateMap<AddCardDto, GetCardDto>();
        }
    }
}
