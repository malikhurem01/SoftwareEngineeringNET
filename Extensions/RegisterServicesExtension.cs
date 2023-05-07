using ResumeMaker.API.Services;
using ResumeMaker.Services;

namespace ResumeMaker.API.Extensions
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthService>();
            service.AddTransient<IInformationService, InformationService>();
        }
    }
}
