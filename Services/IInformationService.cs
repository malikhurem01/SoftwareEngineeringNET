﻿using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs;
using ResumeMaker.API.DTOs.CardDTOs;
using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Services
{
    public interface IInformationService
    {
        Task<ServiceResponse<GetEducationDto>> AddUserEducation(string token, AddEducationDto userInfo);
        Task<ServiceResponse<GetEducationDto>> ModifyUserEducation(string token, ModifyEducationDto userInfo);
        Task<ServiceResponse<GetExperienceDto>> AddUserExperience(string token, AddExperienceDto userInfo);
        Task<ServiceResponse<GetExperienceDto>> ModifyUserExperience(string token, ModifyExperienceDto userInfo);
        Task<ServiceResponse<GetSkillDto>> AddUserSkill(string token, AddSkillDto userInfo);
        Task<ServiceResponse<GetSkillDto>> ModifyUserSkill(string token, ModifySkillDto userInfo);
        Task<ServiceResponse<GetLanguageDto>> AddUserLanguage(string token, AddLanguageDto userInfo);
        Task<ServiceResponse<GetLanguageDto>> ModifyUserLanguage(string token, ModifyLanguageDto userInfo);
        Task<ServiceResponse<GetCardDto>> AddUserCard(string token, AddCardDto userInfo);
        Task<ServiceResponse<GetCardDto>> ModifyUserCard(string token, ModifyCardDto userInfo);
        Task<ServiceResponse<GetUserInfoDto>> GetAllUserInfo(string token);
    }
}
