using App.Infrastructure.Persistence.Configurations;
using App.Tests.Fakes;
using App.Tests.Fakes.Repository;
using App.Tests.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Tests.Fixture.Repository;

/// <summary>
///     Repository fixture
/// </summary>
public class RepositoryFixture : BaseFixture
{
    public RepositoryFixture()
    {
        var services = ServiceCollectionFake.CreateServiceCollectionFake();

        services.AddAppDatabaseSetup(this.ServiceProvider.GetRequiredService<IConfiguration>());
        
        RegisterDbContext(services);

        ServiceProvider = services.BuildServiceProvider();
        
        new SeedAppDbContext().Initialise(ServiceProvider);

    }
}