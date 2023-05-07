using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.API.Services;
using ResumeMaker.Models;

namespace ResumeMaker.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EducationInfoController : ControllerBase
    {
        private readonly IInformationService _informationService;
        public EducationInfoController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetEducationDto>>> AddUserEducation(AddEducationDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.AddUserEducation(tokenValue, userInfo);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetEducationDto>>> ModifyUserEducation(ModifyEducationDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.ModifyUserEducation(tokenValue, userInfo);
        }
    }
}
