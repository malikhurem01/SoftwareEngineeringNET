using AutoMapper;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.Data;
using ResumeMaker.Models.Exceptions;
using ResumeMaker.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace ResumeMaker.API.Services
{
    public class SkillService : ISkillService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SkillService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

    }
}
