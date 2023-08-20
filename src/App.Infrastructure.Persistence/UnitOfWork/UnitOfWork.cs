using System;
using System.Threading.Tasks;
using App.Infrastructure.Persistence.Context;
using App.Infrastructure.Persistence.UnitOfWork.Repositories;
using App.Infrastructure.Persistence.UnitOfWork.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.Persistence.UnitOfWork;

/// <summary>
///     Unit of work
/// </summary>
public class UnitOfWork : IUnitOfWork
{

    public UnitOfWork(IServiceProvider serviceProvider)
    {
        Context = serviceProvider.GetRequiredService<AppDbContext>();
    }

    ~UnitOfWork()
    {
        Context.Dispose();
    }

    /// <summary>
    ///     Database context
    /// </summary>
    public AppDbContext Context { get; }

    /// <summary>
    ///     Save сhanges
    /// </summary>
    public void Save()
    {
        Context.SaveChanges();
    }

    /// <summary>
    ///     Save context changes asynchronously
    /// </summary>
    public async Task SaveAsync()
    {
        await Context.SaveChangesAsync();
    }

    /// <summary>
    ///     Get generic repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Generic repository</returns>
    public IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class, new() 
        => new GenericRepository<TEntity>(Context);
    
}