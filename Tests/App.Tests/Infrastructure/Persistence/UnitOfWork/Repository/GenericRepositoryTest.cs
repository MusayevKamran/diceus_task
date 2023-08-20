using App.Domain.Models;
using App.Infrastructure.Persistence.UnitOfWork;
using App.Infrastructure.Persistence.UnitOfWork.Repositories.Interfaces;
using App.Tests.Fakes.Repository;
using App.Tests.Fixture.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Tests.Infrastructure.Persistence.UnitOfWork.Repository;

/// <summary>
///     Test for GenericRepository
/// </summary>
public class GenericRepositoryTest : IClassFixture<RepositoryFixture>
{
    private readonly IServiceProvider _serviceProvider;

    public GenericRepositoryTest(RepositoryFixture fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
    }

    /// <summary>
    ///     Check AsQueryable method when repository does not contains items
    /// </summary>
    [Fact]
    public async Task GetAsQueryable_SitemapNotExist_AsQueryableGeted()
    {
        //Arrange
        var repository = GetRepositoryWithoutItems();

        //Act
        var contactsQuery = repository.AsQueryable();
        var contacts = await contactsQuery.ToListAsync();

        //Assert
        Assert.Empty(contacts);
    }   
    
    /// <summary>
    ///     Check FirstOrDefault method
    /// </summary>
    [Fact]
    public void SearchByFirstOrDefaultMethod_ContactsExist_ContactGet()
    {
        //Arrange
        var repository = GetSitemapRepository();

        //Act
        var contacts = repository.FirstOrDefault();

        //Assert
        Assert.NotNull(contacts);
    }
    
    /// <summary>
    ///     Get sitemap repository without items
    /// </summary>
    /// <returns>Sitemap repository</returns>
    private IGenericRepository<Contacts> GetRepositoryWithoutItems()
    {
        var scope = _serviceProvider.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        var context = unitOfWork.Context;
        
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        
        return unitOfWork.GetGenericRepository<Contacts>();
    }
    
    /// <summary>
    ///     Get sitemap repository
    /// </summary>
    /// <returns>Sitemap repository</returns>
    private IGenericRepository<Contacts> GetSitemapRepository()
    {
        var scope = _serviceProvider.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        new SeedAppDbContext().Initialise(serviceProvider);
        var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        var sitemapRepository = unitOfWork.GetGenericRepository<Contacts>();

        return sitemapRepository;
    }
}