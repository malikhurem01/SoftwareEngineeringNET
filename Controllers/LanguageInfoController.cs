using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.API.Services;
using ResumeMaker.Models;

namespace ResumeMaker.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguageInfoController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageInfoController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> AddUserLanguage(AddLanguageDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _languageService.AddUserLanguage(tokenValue, userInfo);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetLanguageDto>>> ModifyUserLanguage(ModifyLanguageDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _languageService.ModifyUserLanguage(tokenValue, userInfo);
        }
    }
}
