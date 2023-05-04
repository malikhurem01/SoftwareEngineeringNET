using Microsoft.EntityFrameworkCore;
using ResumeMaker.Data;

namespace ResumeMaker.Extensions
{
    public static class RegisterDBContextExtension
    {
        public static void RegisterDBContext(this IServiceCollection service, ConfigurationManager config)
        {
            service.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}
