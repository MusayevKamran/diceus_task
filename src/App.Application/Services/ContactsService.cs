using System;
using App.Application.Interfaces;
using App.Domain.Models;
using App.Infrastructure.Persistence.UnitOfWork;
using App.Infrastructure.Persistence.UnitOfWork.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace App.Application.Services;

// Declare the ContactsService class, a subtype of GenericRepository for Contacts.
public class ContactsService : GenericRepository<Contacts>, IContactsService
{
    // Define the ContactsService constructor that accepts a serviceProvider parameter.
    // Invoke the base class constructor (GenericRepository) with a Context
    // obtained from a UnitOfWork retrieved from the provided serviceProvider.
    public ContactsService(IServiceProvider serviceProvider) 
        : base(serviceProvider.GetRequiredService<IUnitOfWork>().Context)
    {
    }
}