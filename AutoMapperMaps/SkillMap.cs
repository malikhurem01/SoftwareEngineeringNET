using AutoMapper;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.AutoMapperMaps
{
    public class SkillMap : Profile
    {
        public SkillMap() {
            CreateMap<AddSkillDto, Skill>();
            CreateMap<GetSkillDto, AddSkillDto>();
            CreateMap<GetSkillDto, Skill>();
            CreateMap<AddSkillDto, GetSkillDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<ModifySkillDto, Skill>();
        }
    }
}
