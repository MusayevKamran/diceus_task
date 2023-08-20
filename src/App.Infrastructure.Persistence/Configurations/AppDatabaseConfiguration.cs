using System;
using App.Infrastructure.Persistence.Context;
using App.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.Persistence.Configurations
{
    // Defines a static class to manage database configuration setups.
    public static class AppDatabaseConfiguration
    {
        // Extension method to add database setup configurations to the service collection.
        public static void AddAppDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            // Ensures that the service collection is not null.
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Configures the application's database context with the SQL Server settings obtained from the configuration.
            // The context uses a connection string named "DefaultConnection" from configuration providers, for example, appsettings.json file.
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Adds the application's database context to the service collection as a service type.
            services.AddDbContext<AppDbContext>();
            
            // Registers the unit of work class to be used for dependency injection throughout the application.
            // The scoped lifetime service means that the instance of the UnitOfWork service is created once per client request.
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
