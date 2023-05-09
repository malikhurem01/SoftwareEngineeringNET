using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs;
using ResumeMaker.Models;

namespace ResumeMaker.API.Services
{
    public interface IInformationService
    { 
        Task<ServiceResponse<GetUserInfoDto>> GetAllUserInfo(string token);
    }
}
