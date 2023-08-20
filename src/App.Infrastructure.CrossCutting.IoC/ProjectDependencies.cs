using App.Application.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.CrossCutting.IoC
{
    public static class ProjectDependencies
    {
        /// <summary>
        /// This is an extension method on the IServiceCollection interface that registers different project dependencies.
        /// </summary>
        /// <param name="services">A collection of service descriptors.</param>
        public static void AddProjectSetup(this IServiceCollection services)
        {
            // Registering dependencies defined in the InjectNativeServices class.
            InjectNativeServices.RegisterServices(services);
            
            
            // Registering dependencies defined in the ApplicationLayerConfiguration class.
            ApplicationLayerConfiguration.RegisterServices(services);
        }
    }
}
