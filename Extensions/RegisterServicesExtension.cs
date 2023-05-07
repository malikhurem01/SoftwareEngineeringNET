using ResumeMaker.API.Services;
using ResumeMaker.API.Services.Authentication;

namespace ResumeMaker.API.Extensions
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthService>();
            service.AddTransient<IInformationService, InformationService>();
            service.AddTransient<ISkillService, SkillService>();
            service.AddTransient<IEducationService, EducationService>();
            service.AddTransient<IExperienceService, ExperienceService>();
            service.AddTransient<ILanguageService, LanguageService>();
            service.AddTransient<ICardService, CardService>();
        }
    }
}
