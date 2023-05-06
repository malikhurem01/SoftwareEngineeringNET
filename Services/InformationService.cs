using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResumeMaker.API.DTOs;
using ResumeMaker.API.DTOs.CardDTOs;
using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.API.DTOs.LanguageDTOs;
using ResumeMaker.API.DTOs.SkillDTOs;
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
        public async Task<ServiceResponse<GetEducationDto>> AddUserEducation(string token, AddEducationDto userInfo)
        {
            var response = new ServiceResponse<GetEducationDto>();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = decodedToken.Claims
                .Where(claim => claim.Type
                .Equals("nameid"))
                .Select(claim => claim.Value)
                .SingleOrDefault();

            var user = await _context.Users.Where(user => user.Id.Equals(userId)).Include(user => user.Education).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new EntityNotFoundException("User not found.");
            }

            if(userInfo.DateStart > userInfo.DateEnd)
            {
                throw new BadRequestException("Start date can not be greater than the end date.");
            }
            
            if(userInfo.CurrentlyStudying && userInfo.DateEnd > userInfo.DateStart)
            {
                throw new BadRequestException("Can not have end date if the user is currently studying");
            }

            Education education = _mapper.Map<Education>(userInfo);

            education.UserId = user.Id;

            _context.Education.Add(education);

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetEducationDto>(userInfo);
            response.Message = "Education has been successfully added for user " + user.NormalizedUserName + ".";
            return response;
        }
        public async Task<ServiceResponse<GetEducationDto>> ModifyUserEducation(string token, ModifyEducationDto userInfo)
        {
            var response = new ServiceResponse<GetEducationDto>();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = decodedToken.Claims
                .Where(claim => claim.Type
                .Equals("nameid"))
                .Select(claim => claim.Value)
                .SingleOrDefault();

            var educationFetched = await _context.Education.Where(education => education.Id == userInfo.Id).Where(education => education.UserId.Equals(userId)).Include(education => education.User).FirstOrDefaultAsync();

            if (educationFetched == null)
            {
                throw new EntityNotFoundException("Education Info not found.");
            }

            if (userInfo.DateStart > userInfo.DateEnd)
            {
                throw new BadRequestException("Start date can not be greater than the end date.");
            }

            if (userInfo.CurrentlyStudying && userInfo.DateEnd > userInfo.DateStart)
            {
                throw new BadRequestException("Can not have end date if the user is currently studying");
            }

            educationFetched.DateStart = userInfo.DateStart;
            educationFetched.DateEnd = userInfo.DateEnd;
            educationFetched.CurrentlyStudying = userInfo.CurrentlyStudying;
            educationFetched.Major = userInfo.Major;
            educationFetched.InstitutionTitle = userInfo.InstitutionTitle;

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetEducationDto>(educationFetched);
            response.Message = "Education has been successfully modified for user " + educationFetched.User.NormalizedUserName + ".";
            return response;
        }

        public async Task<ServiceResponse<GetExperienceDto>> AddUserExperience(string token, AddExperienceDto userInfo)
        {
            var response = new ServiceResponse<GetExperienceDto>();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = decodedToken.Claims
                .Where(claim => claim.Type
                .Equals("nameid"))
                .Select(claim => claim.Value)
                .SingleOrDefault();

            var user = await _context.Users.Where(user => user.Id.Equals(userId)).Include(user => user.Experiences).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new EntityNotFoundException("User not found.");
            }

            if (userInfo.DateStart > userInfo.DateEnd)
            {
                throw new BadRequestException("Start date can not be greater than the end date.");
            }

            if (userInfo.CurrentlyWorking && userInfo.DateEnd > userInfo.DateStart)
            {
                throw new BadRequestException("Can not have end date if the user is currently working");
            }

            Experience experience = _mapper.Map<Experience>(userInfo);

            experience.UserId = user.Id;

            _context.Experiences.Add(experience);

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetExperienceDto>(userInfo);
            response.Message = "Experience has been successfully added for user " + user.NormalizedUserName + ".";
            return response;
        }

        public async Task<ServiceResponse<GetSkillDto>> AddUserSkill(string token, AddSkillDto userInfo)
        {
            var response = new ServiceResponse<GetSkillDto>();
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

            Skill skill = _mapper.Map<Skill>(userInfo);

            skill.UserId = user.Id;

            _context.Skills.Add(skill);

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetSkillDto>(userInfo);
            response.Message = "Skill has been successfully added for user " + user.NormalizedUserName + ".";
            return response;
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
