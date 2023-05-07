using AutoMapper;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.Data;
using ResumeMaker.Models.Exceptions;
using ResumeMaker.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace ResumeMaker.API.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LanguageService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetLanguageDto>> AddUserLanguage(string token, AddLanguageDto userInfo)
        {
            var response = new ServiceResponse<GetLanguageDto>();
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

            Language language = _mapper.Map<Language>(userInfo);

            language.UserId = user.Id;

            _context.Languages.Add(language);

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetLanguageDto>(userInfo);
            response.Message = "Language has been successfully added for user " + user.NormalizedUserName + ".";
            return response;
        }
        public async Task<ServiceResponse<GetLanguageDto>> ModifyUserLanguage(string token, ModifyLanguageDto userInfo)
        {
            var response = new ServiceResponse<GetLanguageDto>();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = decodedToken.Claims
                .Where(claim => claim.Type
                .Equals("nameid"))
                .Select(claim => claim.Value)
                .SingleOrDefault();

            var languageFetched = await _context.Languages.Where(language => language.Id == userInfo.Id).Where(language => language.UserId.Equals(userId)).Include(language => language.User).FirstOrDefaultAsync();

            if (languageFetched == null)
            {
                throw new EntityNotFoundException("Lanuage Info not found.");
            }

            languageFetched.Level = userInfo.Level;
            languageFetched.Name = userInfo.Name;

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetLanguageDto>(languageFetched);
            response.Message = "Language has been successfully modified for user " + languageFetched.User.NormalizedUserName + ".";
            return response;
        }
    }
}
