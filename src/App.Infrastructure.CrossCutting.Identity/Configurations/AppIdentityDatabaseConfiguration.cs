using System;
using App.Infrastructure.CrossCutting.Identity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.CrossCutting.Identity.Configurations
{
    /// <summary>
    /// Static class AppIdentityDatabaseConfiguration is responsible for configuring the database context for the application's identity system.
    /// </summary>
    public static class AppIdentityDatabaseConfiguration
    {
        /// <summary>
        /// Adds and configures the identity database context.
        /// </summary>
        /// <param name="services">The IServiceCollection to add services to.</param>
        /// <param name="configuration">Represents a set of key/value application configuration properties</param>
        /// <exception cref="ArgumentNullException">Thrown when the services parameter is null.</exception>
        public static void AddIdentityDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppIdentityDbContext>();
        }
    }
}
