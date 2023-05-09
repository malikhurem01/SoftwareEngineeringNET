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

        [HttpGet("all/info")]
        public async Task<ActionResult<ServiceResponse<UserInfoDto>>> GetAllUserInfo()
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
