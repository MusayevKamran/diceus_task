using System;
using System.Threading.Tasks;
using App.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace App.Api.Controllers;

public class ContactsController : ApiController
{
    // An instance of 'IUserService' to interact with user related data
    private readonly IContactsService _contactsService;

    /// <summary>
    /// Constructor for the 'MyDetailsController' that takes a 'IServiceProvider' to resolve dependencies
    /// </summary>
    /// <param name="serviceProvider">The IServiceProvider to use to get required services</param>
    public ContactsController(IServiceProvider serviceProvider)
    {
        _contactsService = serviceProvider.GetRequiredService<IContactsService>();
    }
    
    /// <summary>
    /// Retrieves the currently logged in user's details
    /// </summary>
    /// <returns>IActionResult with user details in case of successful retrieval</returns>
    // HTTP POST: MyDetails/Index
    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        var user =  await Task.FromResult(_contactsService.Select(x=>x));
        
        return Ok(user);
    }
}