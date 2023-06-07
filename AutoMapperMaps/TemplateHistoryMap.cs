using AutoMapper;
using ResumeMaker.API.DTOs.TemplateDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.AutoMapperMaps
{
    public class TemplateHistoryMap : Profile
    {
        public TemplateHistoryMap() { 
            CreateMap<AddTemplateHistoryDto, TemplateHistory>();
            CreateMap<TemplateHistory, GetTemplateHistoryDto>();
        }
    }
}
