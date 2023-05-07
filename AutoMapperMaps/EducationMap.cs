using AutoMapper;
using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.AutoMapperMaps
{
    public class EducationMap : Profile
    {
        public EducationMap() {
            CreateMap<AddEducationDto, Education>();
            CreateMap<GetEducationDto, AddEducationDto>();
            CreateMap<GetEducationDto, Education>();
            CreateMap<AddEducationDto, GetEducationDto>();
            CreateMap<Education, GetEducationDto>();
            CreateMap<ModifyEducationDto, Education>();
        }
    }
}
