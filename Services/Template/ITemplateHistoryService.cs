using ResumeMaker.API.DTOs.TemplateDTOs;
using ResumeMaker.Models;

namespace ResumeMaker.Services
{
    public interface ITemplateHistoryService
    {
        Task<ServiceResponse<GetTemplateHistoryDto>> AddTemplateHistory(string token, AddTemplateHistoryDto templateInfo);
    }
}
