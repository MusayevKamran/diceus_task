using App.Tests.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Tests.Fakes;

/// <summary>
///     Fake ServiceCollection class for DI unit test
/// </summary>
internal static class ServiceCollectionFake
{
    /// <summary>
    ///     Fake IServiceCollection for unit test
    /// </summary>
    internal static IServiceCollection CreateServiceCollectionFake()
    {
        var serviceCollectionFake = new ServiceCollection();
        
        serviceCollectionFake.AddSingleton<IConfiguration>(_ =>
        {
            var configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddJsonStream(new MemoryStream(TestResources.appsettings_test));

            return configurationBuilder.Build();
        });

        return serviceCollectionFake;
    }
}