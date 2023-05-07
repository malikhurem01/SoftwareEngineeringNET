using AutoMapper;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.AutoMapperMaps
{
    public class LanguageMap : Profile
    {
        public LanguageMap() {
            CreateMap<AddLanguageDto, Language>();
            CreateMap<GetLanguageDto, AddLanguageDto>();
            CreateMap<GetLanguageDto, Language>();
            CreateMap<AddLanguageDto, GetLanguageDto>();
            CreateMap<Language, GetLanguageDto>();
            CreateMap<ModifyLanguageDto, Language>();
        }
    }
}
