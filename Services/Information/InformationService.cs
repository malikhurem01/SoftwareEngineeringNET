using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResumeMaker.API.DTOs;
using ResumeMaker.API.DTOs.CardDTOs;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.Data;
using ResumeMaker.Models;
using ResumeMaker.Models.Exceptions;
using System.IdentityModel.Tokens.Jwt;

namespace ResumeMaker.API.Services
{
    public class InformationService : IInformationService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public InformationService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetUserInfoDto>> GetAllUserInfo(string token)
        {
            var response = new ServiceResponse<GetUserInfoDto>();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = decodedToken.Claims
                .Where(claim => claim.Type
                .Equals("nameid"))
                .Select(claim => claim.Value)
                .SingleOrDefault();

            var user = await _context.Users.Where(user => user.Id.Equals(userId)).Include(user => user.Education).Include(user => user.Experiences).Include(user => user.Languages).Include(user => user.Skills).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new EntityNotFoundException("User not found.");
            }

            response.Data = _mapper.Map<GetUserInfoDto>(user);
            response.Message = "User " + user.NormalizedUserName + "'s data is fetched.";
            return response;
        }
    }
} 
