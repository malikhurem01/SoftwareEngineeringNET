using AutoMapper;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.AutoMapperMaps
{
    public class ExperienceMap : Profile
    {
        public ExperienceMap() {
            CreateMap<AddExperienceDto, Experience>();
            CreateMap<GetExperienceDto, AddExperienceDto>();
            CreateMap<GetExperienceDto, Experience>();
            CreateMap<AddExperienceDto, GetExperienceDto>();
            CreateMap<Experience, GetExperienceDto>();
            CreateMap<ModifyExperienceDto, Experience>();
        }
    }
}
