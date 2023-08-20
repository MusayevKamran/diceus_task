using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.CrossCutting.Identity.Models
{
    /// <summary>
    /// Provides context specific information related to the client making the request. 
    /// Contains methods to access various details about the current user such as Identity, Full Name, Authorization status etc.
    /// </summary>
    public class ContextIdentity
    {
        private static IHttpContextAccessor _accessor;

        /// <summary>
        /// Constructor for the ContextIdentity receives an instance of IServiceProvider
        /// </summary>
        /// <param name="serviceProvider"> An instance of IServiceProvider </param>
        public ContextIdentity(IServiceProvider serviceProvider)
        {
            _accessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        }
        
        /// <summary>
        /// Gets the CurrentLoginId of the user making the request.
        /// </summary>
        public string CurrentLoginId => GetCurrentIdentity();
       
        /// <summary>
        /// Gets the Identity of the current user. Throws an exception if the user is not authorized.
        /// </summary>
        /// <returns>Current User Id as string</returns>
        private string GetCurrentIdentity()
        {
            if (_accessor?.HttpContext?.User?.Claims?.FirstOrDefault()?.Value == null)
            {
                throw new Exception("User is not authorized");
            }

            return _accessor.HttpContext.User.Claims.FirstOrDefault()?.Value;
        }

        /// <summary>
        /// Gets the Name of the user making the request.
        /// </summary>
        public string Name => GetName();
        
        /// <summary>
        /// Gets the Name of the current user. If the Name claim is not present, it tries to get the email claim as the name .
        /// </summary>
        /// <returns>Current user name as string</returns>
        private string GetName()
        {
            return _accessor?.HttpContext?.User.Identity?.Name ??
                   _accessor?.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }

        /// <summary>
        /// Gets the Authorization status of the user making the request.
        /// </summary>
        public bool IsAuthenticated => CheckUserIsAuthenticated();
       
        /// <summary>
        /// Checks whether current user is authenticated or not.
        /// </summary>
        /// <returns>Boolean indicating user's authentication status</returns>
        private bool CheckUserIsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        /// <summary>
        /// Gets all Claims belonging to the Identity of the current user.
        /// </summary>
        /// <returns>IEnumerable of claims of the user</returns>
        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
