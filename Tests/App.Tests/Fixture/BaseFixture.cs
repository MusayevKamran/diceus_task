using App.Infrastructure.Persistence.Context;
using App.Tests.Fakes;
using App.Tests.Fakes.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace App.Tests.Fixture;

/// <summary>
/// Base fixture
/// </summary>
public abstract class BaseFixture
{
    protected BaseFixture()
    {
        ServiceProvider = ServiceCollectionFake.CreateServiceCollectionFake().BuildServiceProvider();
    }
    
    /// <summary>
    /// Service provider
    /// </summary>
    public IServiceProvider ServiceProvider { get; set; }
    
    /// <summary>
    ///     Register in memory db context
    /// </summary>
    /// <param name="services">Service collection</param>
    protected static void RegisterDbContext(IServiceCollection services)
    {
        // Remove the app's SeoDbContext registration.
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
        if (descriptor != null) services.Remove(descriptor);

        services.AddSingleton<IDbContextOptionsTest, DbContextOptionsTest>();

        services
            .AddEntityFrameworkInMemoryDatabase()
            .AddDbContext<AppDbContext>((sp, options) =>
            {
                var databaseId = sp.GetRequiredService<IDbContextOptionsTest>().DatabaseId;

                options
                    .EnableSensitiveDataLogging()
                    .UseInMemoryDatabase(databaseName: $"FakeDb_{databaseId}")
                    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                    .UseInternalServiceProvider(sp);
            });
    }
}