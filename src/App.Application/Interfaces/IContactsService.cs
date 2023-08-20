using App.Domain.Models;
using App.Infrastructure.Persistence.UnitOfWork.Repositories.Interfaces;

namespace App.Application.Interfaces;

// Declares the `IContactsService` interface which extends from the `IGenericRepository<Contacts>` interface.
// This interface provides a way to perform complex data operations on a `Contacts` object.
// However, as an interface, it doesn't provide an implementation for these operations.
// Classes that implement this interface are required to provide the concrete implementation for these operations.
public interface IContactsService : IGenericRepository<Contacts>
{
    // More methods can be placed in here if needed.
}