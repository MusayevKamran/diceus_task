using System.Threading.Tasks;
using App.Infrastructure.Persistence.Context;
using App.Infrastructure.Persistence.UnitOfWork.Repositories.Interfaces;

namespace App.Infrastructure.Persistence.UnitOfWork;

/// <summary>
///     Unit of work
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///     Database context
    /// </summary>
    AppDbContext Context { get; }
    
    /// <summary>
    ///     Get generic repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Generic repository</returns>
    IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class, new();
    
    /// <summary>
    ///     Save сhanges
    /// </summary>
    void Save();

    /// <summary>
    ///     Save context changes asynchronously
    /// </summary>
    Task SaveAsync();
}