using App.Application.Interfaces;
using App.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App.Application.Configurations
{
    /// <summary>
    /// The ApplicationLayerConfiguration class provides registration methods for services in the application layer.
    /// </summary>
    public static class ApplicationLayerConfiguration
    {
        /// <summary>
        /// This method registers all the required services to the provided ServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection instance which the services are being added to.</param>
        public static void RegisterServices(IServiceCollection services)
        {
            // Register IUserService with a scoped lifestyle, where the UserService implementation is used.
            services.AddScoped<IUserService, UserService>();
            
            // Register IContactsService with a scoped lifestyle, where the ContactsService implementation is used.
            services.AddScoped<IContactsService, ContactsService>();
        }
    }
}
