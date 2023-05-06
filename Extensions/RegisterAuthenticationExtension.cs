using Microsoft.AspNetCore.Identity;
using ResumeMaker.Data;

namespace ResumeMaker.Extensions
{
    public static class RegisterAuthenticationExtension
    {
        public static void RegisterIdentityAuthentication(this IServiceCollection service, ConfigurationManager config)
        {
            service.AddIdentityCore<IdentityUser>(setupAction =>
            {
                setupAction.User.AllowedUserNameCharacters = config.GetSection("Authentication:AllowedUserNameCharacters").Value;
                setupAction.User.RequireUniqueEmail = true;
                setupAction.Password.RequireDigit = false;
                setupAction.Password.RequiredUniqueChars = 2;
                setupAction.Password.RequireLowercase = false;
                setupAction.Password.RequireNonAlphanumeric = false;
                setupAction.Password.RequireUppercase = false;
                setupAction.Password.RequiredLength = 5;
                setupAction.SignIn.RequireConfirmedEmail = false;
                setupAction.SignIn.RequireConfirmedPhoneNumber = false;
            });
            new IdentityBuilder(typeof(IdentityUser), typeof(IdentityRole), service)
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddSignInManager<SignInManager<IdentityUser>>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
        }
    }
}
