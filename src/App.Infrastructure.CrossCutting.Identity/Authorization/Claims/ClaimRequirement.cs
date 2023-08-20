using Microsoft.AspNetCore.Authorization;

namespace App.Infrastructure.CrossCutting.Identity.Authorization.Claims
{
    /// <summary>
    /// Class representing a claim authorization requirement
    /// </summary>
    public class ClaimRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Initializes a new instance of the ClaimRequirement class 
        /// </summary>
        /// <param name="claimName">The identifier of the claim</param>
        /// <param name="claimValue">The value of the claim</param>
        public ClaimRequirement(string claimName, string claimValue)
        {
            ClaimName = claimName;
            ClaimValue = claimValue;
        }

        /// <summary>
        /// Gets or sets the name of the claim
        /// </summary>
        public string ClaimName { get; set; }

        /// <summary>
        /// Gets or sets the value of the claim
        /// </summary>
        public string ClaimValue { get; set; }
    }
}