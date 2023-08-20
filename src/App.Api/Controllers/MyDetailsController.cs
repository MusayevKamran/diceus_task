using System;
using System.Threading.Tasks;
using App.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace App.Api.Controllers
{
    /// <summary>
    /// Controller that handles actions related to my details.
    /// </summary>
    public class MyDetailsController : ApiController
    {
        // An instance of 'IUserService' to interact with user related data
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor for the 'MyDetailsController' that takes a 'IServiceProvider' to resolve dependencies
        /// </summary>
        /// <param name="serviceProvider">The IServiceProvider to use to get required services</param>
        public MyDetailsController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
        }

        /// <summary>
        /// Retrieves the currently logged in user's details
        /// </summary>
        /// <returns>IActionResult with user details in case of successful retrieval</returns>
        // HTTP POST: MyDetails/Index
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetCurrentUserAsync();

            return Ok(user);
        }
    }
}