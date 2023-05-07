using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.API.Services;
using ResumeMaker.Models;

namespace ResumeMaker.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ExperienceInfoController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        public ExperienceInfoController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetExperienceDto>>> AddUserExperience(AddExperienceDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _experienceService.AddUserExperience(tokenValue, userInfo);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetExperienceDto>>> ModifyUserExperience(ModifyExperienceDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _experienceService.ModifyUserExperience(tokenValue, userInfo);
        }
    }
}
