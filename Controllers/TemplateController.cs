using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeMaker.API.DTOs.TemplateDTOs;
using ResumeMaker.Models;
using ResumeMaker.Services;

namespace ResumeMaker.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateHistoryService _templateHistoryService;
        public TemplateController(ITemplateHistoryService templateHistoryService) {
            _templateHistoryService = templateHistoryService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<GetTemplateHistoryDto>>> AddTemplateHistory(AddTemplateHistoryDto templateInfo) {
            Request.Headers.TryGetValue("Authorization", out var token);
            string tokenValue = token
                .ToString()
                .Split(" ")
                .ElementAt(1);
            return await _templateHistoryService.AddTemplateHistory(tokenValue, templateInfo);
        }
    }
}
