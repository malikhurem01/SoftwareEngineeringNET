using AutoMapper;
using ResumeMaker.API.DTOs.CardDTOs;
using ResumeMaker.Data;
using ResumeMaker.Models.Exceptions;
using ResumeMaker.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace ResumeMaker.API.Services
{
    public class CardService : ICardService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CardService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCardDto>> AddUserCard(string token, AddCardDto userInfo)
        {
            var response = new ServiceResponse<GetCardDto>();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = decodedToken.Claims
                .Where(claim => claim.Type
                .Equals("nameid"))
                .Select(claim => claim.Value)
                .SingleOrDefault();

            var user = await _context.Users.Where(user => user.Id.Equals(userId)).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new EntityNotFoundException("User not found.");
            }

            Card card = _mapper.Map<Card>(userInfo);

            card.UserId = user.Id;

            _context.Cards.Add(card);

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetCardDto>(userInfo);
            response.Message = "Card has been successfully added for user " + user.NormalizedUserName + ".";
            return response;
        }

        public async Task<ServiceResponse<GetCardDto>> ModifyUserCard(string token, ModifyCardDto userInfo)
        {
            var response = new ServiceResponse<GetCardDto>();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = decodedToken.Claims
                .Where(claim => claim.Type
                .Equals("nameid"))
                .Select(claim => claim.Value)
                .SingleOrDefault();

            var cardFetched = await _context.Cards.Where(card => card.Id == userInfo.Id).Where(card => card.UserId.Equals(userId)).Include(card => card.User).FirstOrDefaultAsync();

            if (cardFetched == null)
            {
                throw new EntityNotFoundException("Card Info not found.");
            }

            cardFetched.DateEnd = userInfo.DateEnd;
            cardFetched.Name = userInfo.Name;
            cardFetched.Number = userInfo.Number;
            cardFetched.CVC = userInfo.CVC;

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetCardDto>(cardFetched);
            response.Message = "Card has been successfully modified for user " + cardFetched.User.NormalizedUserName + ".";
            return response;
        }
    }
}
