using ResumeMaker.API.AutoMapperMaps;

namespace ResumeMaker.API.Extensions
{
    public static class RegisterAutoMapperExtension
    {
        public static void RegisterAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(UserMap));
            service.AddAutoMapper(typeof(InfoMap));
        }
    }
}
