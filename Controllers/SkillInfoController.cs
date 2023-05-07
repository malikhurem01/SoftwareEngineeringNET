using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.API.Services;
using ResumeMaker.Models;

namespace ResumeMaker.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SkillInfoController : ControllerBase
    {
        private readonly IInformationService _informationService;
        public SkillInfoController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetSkillDto>>> AddUserSkill(AddSkillDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.AddUserSkill(tokenValue, userInfo);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetSkillDto>>> ModifyUserSkill(ModifySkillDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.ModifyUserSkill(tokenValue, userInfo);
        }
    }
}
