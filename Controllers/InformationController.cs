using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs;
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

        [HttpGet]
        public Task<ActionResult<ServiceResponse<AddInformationDto>>> GetUserInformation()
        {
            return null;
        }

        [HttpDelete]
        public Task<ActionResult<ServiceResponse<string>>> RemoveUserInformation(AddInformationDto userInfo)
        {
            return null;
        }

    }
}
