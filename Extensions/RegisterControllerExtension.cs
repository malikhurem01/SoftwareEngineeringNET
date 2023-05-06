using System.Text.Json.Serialization;

namespace ResumeMaker.API.Extensions
{
    public static class RegisterControllerExtension
    {
        public static void RegisterControllers(this IServiceCollection service)
        {
            service.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }
    }
}
