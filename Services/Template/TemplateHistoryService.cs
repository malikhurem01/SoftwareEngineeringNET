using Microsoft.EntityFrameworkCore;
using ResumeMaker.API.DTOs.SkillDTOs;
using ResumeMaker.Models.Exceptions;
using ResumeMaker.Models;
using System.IdentityModel.Tokens.Jwt;
using ResumeMaker.API.DTOs.TemplateDTOs;
using AutoMapper;
using ResumeMaker.Data;
using ResumeMaker.API.Services;
using ResumeMaker.API.DTOs.ExperienceDTOs;
using ResumeMaker.API.DTOs.EducationDTOs;
using ResumeMaker.API.DTOs.LanguageDTOs;

namespace ResumeMaker.Services
{
    public class TemplateHistoryService : ITemplateHistoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IExperienceService _experienceService;
        private readonly IEducationService _educationService;
        private readonly ISkillService _skillService;
        private readonly ILanguageService _languageService;
        public TemplateHistoryService(DataContext context, IMapper mapper, IExperienceService experienceService, IEducationService educationService, ISkillService skillService, ILanguageService languageService)
        {
            _context = context;
            _mapper = mapper;
            _experienceService = experienceService;
            _educationService = educationService;
            _skillService = skillService;  
            _languageService = languageService;
        }
        public async Task<ServiceResponse<GetTemplateHistoryDto>> AddTemplateHistory(string token, AddTemplateHistoryDto templateInfo)
        {
            var response = new ServiceResponse<GetTemplateHistoryDto>();
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

            if(templateInfo.Id != null)
            {
                var existingTemplate = await _context.TemplateHistory.Where(template => template.Id == templateInfo.Id).FirstOrDefaultAsync();

                if(existingTemplate != null)
                {
                    //Experience
                    foreach(Experience exp in existingTemplate.Experience)
                    {
                        var updatedExperience = templateInfo.Experience.Find(experience => experience.Id == exp.Id);
                        var indexToRemove = templateInfo.Experience.FindIndex(experience => experience.Id == exp.Id);
                        templateInfo.Experience.RemoveAt(indexToRemove);
                        if(updatedExperience != null)
                        {
                            exp.CurrentlyWorking = updatedExperience.CurrentlyWorking;
                            exp.DateEnd = (DateTime)updatedExperience.DateEnd;
                            exp.JobTitle = updatedExperience.JobTitle;
                            exp.Description = updatedExperience.Description;
                            exp.DateStart = updatedExperience.DateStart;
                            exp.Location = updatedExperience.Location;
                            exp.CompanyName = updatedExperience.CompanyName;
                            exp.WorkingHours = updatedExperience.WorkingHours;
                        }
                        else
                        {
                            existingTemplate.Experience.Remove(exp);
                        }
                    }
                    foreach(AddExperienceDto exp in templateInfo.Experience)
                    {
                        exp.TemplateHistoryId = existingTemplate.Id;
                        await _experienceService.AddUserExperience(token, exp);
                    }

                    //Education
                    foreach (Education edu in existingTemplate.Education)
                    {
                        var updatedEducation = templateInfo.Education.Find(education => education.Id == edu.Id);
                        var indexToRemove = templateInfo.Education.FindIndex(education => education.Id == edu.Id);
                        templateInfo.Education.RemoveAt(indexToRemove);
                        if (updatedEducation != null)
                        {
                            edu.CurrentlyStudying = updatedEducation.CurrentlyStudying;
                            edu.DateEnd = (DateTime)updatedEducation.DateEnd;
                            edu.Major = updatedEducation.Major;
                            edu.DateStart = updatedEducation.DateStart;
                            edu.Location = updatedEducation.Location;
                            edu.Description = updatedEducation.Description;
                            edu.InstitutionTitle = updatedEducation.InstitutionTitle;
                        }
                        else
                        {
                            existingTemplate.Education.Remove(edu);
                        }
                    }
                    foreach (AddEducationDto exp in templateInfo.Education)
                    {
                        exp.TemplateHistoryId = existingTemplate.Id;
                        await _educationService.AddUserEducation(token, exp);
                    }
                }
            }

            TemplateHistory templateHistory = _mapper.Map<TemplateHistory>(templateInfo);

            templateHistory.UserId = user.Id;

            templateHistory.Experience = null;
            templateHistory.Education = null;
            templateHistory.Languages = null;
            templateHistory.Skills = null;

            _context.TemplateHistory.Add(templateHistory);

            await _context.SaveChangesAsync();

            foreach (AddExperienceDto exp in templateInfo.Experience)
            {
                exp.TemplateHistoryId = templateHistory.Id;
                await _experienceService.AddUserExperience(token, exp);
            }

            foreach (AddEducationDto edu in templateInfo.Education)
            {
                edu.TemplateHistoryId = templateHistory.Id;
                await _educationService.AddUserEducation(token, edu);
            }

            foreach(AddSkillDto skill in templateInfo.Skills)
            {
                skill.TemplateHistoryId = templateHistory.Id;
                await _skillService.AddUserSkill(token, skill);
            }

            foreach(AddLanguageDto lang in templateInfo.Languages)
            {
                lang.TemplateHistoryId = templateHistory.Id;
                await _languageService.AddUserLanguage(token, lang);
            }

            response.Data = _mapper.Map<GetTemplateHistoryDto>(templateHistory);
            response.Message = "Template history has been successfully been saved for user " + user.NormalizedUserName + ".";
            return response;
        }
    }
}
