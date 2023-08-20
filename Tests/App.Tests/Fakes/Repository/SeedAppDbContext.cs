using App.Domain.Models;
using App.Infrastructure.Persistence.Context;
using App.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Tests.Fakes.Repository;

/// <summary>
///  Fake class for SeoDbContext
/// </summary>
public class SeedAppDbContext
{
    private AppDbContext Context { get; set; }

    public SeedAppDbContext()
    {
        Context = new AppDbContext(new DbContextOptions<AppDbContext>());
    }

    public SeedAppDbContext(AppDbContext context)
    {
        Context = context;
    }

    /// <summary>
    ///  Generate data for SeoDbContext DbSets
    /// </summary>
    private void GenerateFakeSeoDbContext()
    {
        Context.Database.EnsureDeleted();
        Context.Database.EnsureCreated();
        
        for (var i = 1; i <= 10; i++)
        {
            AddContactsFiles(i);
        }
        
        Context.SaveChanges();
    }
    

    /// <summary>
    ///  Initialise db Context and fill data
    /// </summary>
    public void Initialise(IServiceProvider serviceProvider)
    {
        Context = serviceProvider.GetRequiredService<IUnitOfWork>().Context;

        GenerateFakeSeoDbContext();
    }
    
    /// <summary>
    ///  Generate data for RobotFiles DbSets
    /// </summary>
    private void AddContactsFiles(int i)
    {
        if (!Context.Contacts.Any())
        {
            Context.Contacts.Add(new Contacts()
            {
                Id =  i,
                UserId =  i,
                Email = "test" +  i + "@gmail.com",
                Name = "RandName " +  i,
                Surname = "RandSurname "+  i,
                Phone = "12344313" + i
            });
        }
    }
}
