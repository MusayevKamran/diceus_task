using System;
using App.Infrastructure.CrossCutting.Identity.Context;
using App.Infrastructure.CrossCutting.Identity.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Admin.Configurations
{
    /// <summary>
    /// This static class is responsible for configuration related to Identity and Authentication.
    /// </summary>
    public static class IdentityConfiguration
    {
        /// <summary>
        /// Configures the identity-related services for the application.
        /// Adds the default identity system configuration for the specified User type (Login in this case).
        /// The identity stores are configured to use EntityFramework.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <exception cref="ArgumentNullException">Thrown when services are null.</exception>
        public static void AddIdentitySetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDefaultIdentity<Login>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddEntityFrameworkStores<AppIdentityDbContext>();
        }
    }
}