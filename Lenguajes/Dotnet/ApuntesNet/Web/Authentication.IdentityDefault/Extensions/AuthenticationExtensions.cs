using Microsoft.AspNetCore.Identity;

namespace Authentication.IdentityDefault.Extensions;

internal static class AuthenticationExtensions
{
    internal static void AddAuthenticationProtocol(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddAuthorization()
            .AddIdentityApiEndpoints<IdentityUser<int>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                options.SignIn.RequireConfirmedEmail = false;
            })
            .AddUserManager<UserManager<IdentityUser<int>>>()
            .AddRoles<IdentityRole<int>>()
            .AddRoleManager<RoleManager<IdentityRole<int>>>()
            .AddEntityFrameworkStores<DatabaseDbContext>();
    }
}