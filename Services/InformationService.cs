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

            Experience experience = _mapper.Map<Experience>(userInfo);

            experience.UserId = user.Id;

            _context.Experiences.Add(experience);

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetExperienceDto>(userInfo);
            response.Message = "Experience has been successfully added for user " + user.NormalizedUserName + ".";
            return response;
        }

        public async Task<ServiceResponse<GetExperienceDto>> ModifyUserExperience(string token, ModifyExperienceDto userInfo)
        {
            var response = new ServiceResponse<GetExperienceDto>();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = decodedToken.Claims
                .Where(claim => claim.Type
                .Equals("nameid"))
                .Select(claim => claim.Value)
                .SingleOrDefault();

            var experienceFetched = await _context.Experiences.Where(experience => experience.Id == experience.Id).Where(experience => experience.UserId.Equals(userId)).Include(experience => experience.User).FirstOrDefaultAsync();

            if (experienceFetched == null)
            {
                throw new EntityNotFoundException("Experience Info not found.");
            }

            if (userInfo.DateStart > userInfo.DateEnd)
            {
                throw new BadRequestException("Start date can not be greater than the end date.");
            }

            experienceFetched.DateStart = userInfo.DateStart;
            experienceFetched.DateEnd = userInfo.DateEnd;
            experienceFetched.CurrentlyWorking = userInfo.CurrentlyWorking;
            experienceFetched.CompanyName = userInfo.CompanyName;
            experienceFetched.Description = userInfo.Description;
            experienceFetched.Location = userInfo.Location;
            experienceFetched.JobTitle = userInfo.JobTitle;

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetExperienceDto>(experienceFetched);
            response.Message = "Experience has been successfully modified for user " + experienceFetched.User.NormalizedUserName + ".";
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
        public async Task<ServiceResponse<GetSkillDto>> ModifyUserSkill(string token, ModifySkillDto userInfo)
        {
            var response = new ServiceResponse<GetSkillDto>();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = decodedToken.Claims
                .Where(claim => claim.Type
                .Equals("nameid"))
                .Select(claim => claim.Value)
                .SingleOrDefault();

            var skillFetched = await _context.Skills.Where(skill => skill.Id == skill.Id).Where(skill => skill.UserId.Equals(userId)).Include(skill => skill.User).FirstOrDefaultAsync();

            if (skillFetched == null)
            {
                throw new EntityNotFoundException("Skill Info not found.");
            }

            skillFetched.Level = userInfo.Level;
            skillFetched.Name = userInfo.Name;

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetSkillDto>(skillFetched);
            response.Message = "Skill has been successfully modified for user " + skillFetched.User.NormalizedUserName + ".";
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
