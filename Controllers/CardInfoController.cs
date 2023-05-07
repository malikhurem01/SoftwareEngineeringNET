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
        private readonly ICardService _cardService;
        public CardInfoController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetCardDto>>> AddUserCard(AddCardDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _cardService.AddUserCard(tokenValue, userInfo);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetCardDto>>> ModifyUserCard(ModifyCardDto userInfo)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _cardService.ModifyUserCard(tokenValue, userInfo);
        }
    }
}
