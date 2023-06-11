using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using ResumeMaker.API.DTOs;
using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.Data;
using ResumeMaker.Models;
using ResumeMaker.Models.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ResumeMaker.API.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager, IMapper mapper, DataContext context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }
        public Task<ServiceResponse<GetUserDto>> GetUserByToken(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetUserDto>> Login(UserLoginDto user)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();
            var fetchedUser = await _userManager.FindByEmailAsync(user.Email);
            if (fetchedUser == null)
            {
                throw new BadRequestException("Wrong credentials");
            }
            else
            {
                var result = await _signInManager.CheckPasswordSignInAsync(fetchedUser, user.Password, false);
                if (!result.Succeeded)
                {
                    throw new BadRequestException("Wrong credentials");
                }
                var getUserDto = _mapper.Map<GetUserDto>(fetchedUser);
                getUserDto.Token = CreateToken((User)fetchedUser);
                response.Data = getUserDto;
                response.Message = "User " + user.Email + " has successfully logged in.";
            }
            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> RegisterUser(RegisterUserDto user)
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();
            User userMap = new User();
            userMap.FirstName = user.FirstName;
            userMap.LastName = user.LastName;
            userMap.Email = user.Email;
            userMap.UserName = user.FirstName.ToLower() + user.LastName.ToLower();
            var result = await _userManager.CreateAsync(userMap, user.Password);
            StringBuilder stringBuilder = new StringBuilder();
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    stringBuilder.Append(error.Description);
                }
                throw new BadRequestException(stringBuilder.ToString());
            }
            response = await Login(_mapper.Map<UserLoginDto>(user));
            return response;
        }
        public async Task<ServiceResponse<GetUserDto>> CurrentUser(string token)
        {
            var response = new ServiceResponse<GetUserDto>();
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

            response.Data = _mapper.Map<GetUserDto>(user);
            response.Message = "User successfully fetched.";
            return response;
        }


        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("JWTSettings:SecurityKey").Value));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(int.Parse(_configuration.GetSection("JWTSettings:ExpiryInMinutes").Value)),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
