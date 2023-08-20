using Microsoft.Extensions.DependencyInjection;
using App.Infrastructure.CrossCutting.Identity.Authorization.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace App.Infrastructure.CrossCutting.IoC
{
    public static class InjectNativeServices
    {
        // This static method is used to register your services
        public static void RegisterServices(IServiceCollection services)
        {
            // Add HttpContextAccessor as singleton
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            // Add ClaimsRequirementHandler as an Singleton authorization handler
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();
        }
    }
}
