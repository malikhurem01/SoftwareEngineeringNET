using AutoMapper;
using ResumeMaker.API.DTOs;
using ResumeMaker.API.DTOs.CardDTOs;
using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.AutoMapperMaps
{
    public class InfoMap : Profile
    {
        public InfoMap()
        {
            CreateMap<AddEducationDto, Education>();
            CreateMap<GetEducationDto, AddEducationDto>();
            CreateMap<GetEducationDto, Education>();
            CreateMap<AddEducationDto, GetEducationDto>();
            CreateMap<Education, GetEducationDto>();
            CreateMap<ModifyEducationDto, Education>();

            CreateMap<AddExperienceDto, Experience>();
            CreateMap<GetExperienceDto, AddExperienceDto>();
            CreateMap<GetExperienceDto, Experience>();
            CreateMap<AddExperienceDto, GetExperienceDto>();
            CreateMap<Experience, GetExperienceDto>();
            CreateMap<ModifyExperienceDto, Experience>();

            CreateMap<AddSkillDto, Skill>();
            CreateMap<GetSkillDto, AddSkillDto>();
            CreateMap<GetSkillDto, Skill>();
            CreateMap<AddSkillDto, GetSkillDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<ModifySkillDto, Skill>();

            CreateMap<AddLanguageDto, Language>();
            CreateMap<GetLanguageDto, AddLanguageDto>();
            CreateMap<GetLanguageDto, Language>();
            CreateMap<AddLanguageDto, GetLanguageDto>();
            CreateMap<Language, GetLanguageDto>();
            CreateMap<ModifyLanguageDto, Language>();

            CreateMap<AddCardDto, Card>();
            CreateMap<GetCardDto, AddCardDto>();
            CreateMap<GetCardDto, Card>();
            CreateMap<AddCardDto, GetCardDto>();
            CreateMap<Card, GetCardDto>();
            CreateMap<ModifyCardDto, Card>();

            CreateMap<User, GetUserInfoDto>()
                .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.Education))
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experiences))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages));
        }
    }
}
