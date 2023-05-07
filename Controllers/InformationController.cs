using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs;
using ResumeMaker.API.DTOs.CardDTOs;
using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.API.Services;
using ResumeMaker.Models;

namespace ResumeMaker.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class InformationController : ControllerBase
    {
        private readonly IInformationService _informationService;
        public InformationController(IInformationService informationService) {
            _informationService = informationService;
        }

        [HttpPost("education")]
        public async Task<ActionResult<ServiceResponse<GetEducationDto>>> AddUserEducation(AddEducationDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.AddUserEducation(tokenValue, userInfo);
        }

        [HttpPut("education")]
        public async Task<ActionResult<ServiceResponse<GetEducationDto>>> ModifyUserEducation(ModifyEducationDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.ModifyUserEducation(tokenValue, userInfo);
        }

        [HttpPost("experience")]
        public async Task<ActionResult<ServiceResponse<GetExperienceDto>>> AddUserExperience(AddExperienceDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.AddUserExperience(tokenValue, userInfo);
        }

        [HttpPut("experience")]
        public async Task<ActionResult<ServiceResponse<GetExperienceDto>>> ModifyUserExperience(ModifyExperienceDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.ModifyUserExperience(tokenValue, userInfo);
        }

        [HttpPost("skill")]
        public async Task<ActionResult<ServiceResponse<GetSkillDto>>> AddUserSkill(AddSkillDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.AddUserSkill(tokenValue, userInfo);
        }

        [HttpPut("skill")]
        public async Task<ActionResult<ServiceResponse<GetSkillDto>>> ModifyUserSkill(ModifySkillDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.ModifyUserSkill(tokenValue, userInfo);
        }

        [HttpPost("language")]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> AddUserLanguage(AddLanguageDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.AddUserLanguage(tokenValue, userInfo);
        }

        [HttpPut("language")]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> ModifyUserLanguage(ModifyLanguageDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.ModifyUserLanguage(tokenValue, userInfo);
        }

        [HttpPost("card")]
        public async Task<ActionResult<ServiceResponse<GetCardDto>>> AddUserCard(AddCardDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.AddUserCard(tokenValue, userInfo);
        }

        [HttpPut("card")]
        public async Task<ActionResult<ServiceResponse<GetCardDto>>> ModifyUserCard(ModifyCardDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.ModifyUserCard(tokenValue, userInfo);
        }

        [HttpGet("all/info")]
        public async Task<ActionResult<ServiceResponse<GetUserInfoDto>>> GetAllUserInfo()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.GetAllUserInfo(tokenValue);
        }
    }
}
