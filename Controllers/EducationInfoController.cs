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
        private readonly IEducationService _educationService;
        public EducationInfoController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetEducationDto>>> AddUserEducation(AddEducationDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _educationService.AddUserEducation(tokenValue, userInfo);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetEducationDto>>> ModifyUserEducation(ModifyEducationDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _educationService.ModifyUserEducation(tokenValue, userInfo);
        }
    }
}
