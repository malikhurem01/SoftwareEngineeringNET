using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs.CardDTOs;
using ResumeMaker.API.Services;
using ResumeMaker.Models;

namespace ResumeMaker.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CardInfoController : ControllerBase
    {
        private readonly IInformationService _informationService;
        public CardInfoController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetCardDto>>> AddUserCard(AddCardDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.AddUserCard(tokenValue, userInfo);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetCardDto>>> ModifyUserCard(ModifyCardDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _informationService.ModifyUserCard(tokenValue, userInfo);
        }
    }
}
