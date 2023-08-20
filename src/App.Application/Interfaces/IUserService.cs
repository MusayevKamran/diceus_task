using System.Threading.Tasks;
using App.Domain.Models;
using App.Infrastructure.Persistence.UnitOfWork.Repositories.Interfaces;

namespace App.Application.Interfaces
{
    /// <summary>
    /// Interface for User related services. Inherits the functionality of the IGenericRepository of User.
    /// </summary>
    public interface IUserService : IGenericRepository<User>
    {
        /// <summary>
        /// Returns the User object of the currently authenticated user, based on the provided user context.
        /// </summary>
        /// <returns>The User object representing the authenticated user.</returns>
          Task<User> GetCurrentUserAsync();
    }
}
