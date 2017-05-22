using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlataformaDeEnsino.Identity.ServiceCollectionExtensionsIdentity
{
    public static class ServiceCollectionExtensionsIdentity
    {
        public static void RegistrarDependenciasIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // Cookie settings
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.Cookies.ApplicationCookie.LoginPath = "/Login";
                options.Cookies.ApplicationCookie.LogoutPath = "/LogOff";
                options.Cookies.ApplicationCookie.AccessDeniedPath = "/RedirecionarUsuario";

                // User settings
                options.User.RequireUniqueEmail = true;
            });
        }
    }
}