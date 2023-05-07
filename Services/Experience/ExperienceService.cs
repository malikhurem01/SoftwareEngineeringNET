using AutoMapper;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.Data;
using ResumeMaker.Models.Exceptions;
using ResumeMaker.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace ResumeMaker.API.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ExperienceService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}
