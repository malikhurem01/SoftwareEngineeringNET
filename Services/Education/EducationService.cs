using AutoMapper;
using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.Data;
using ResumeMaker.Models.Exceptions;
using ResumeMaker.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace ResumeMaker.API.Services
{
    public class EducationService : IEducationService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EducationService(DataContext context, IMapper mapper)
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

            if (userInfo.DateStart > userInfo.DateEnd)
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
    }
}
