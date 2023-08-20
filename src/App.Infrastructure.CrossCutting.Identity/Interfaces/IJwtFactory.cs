using System.Security.Claims;
using System.Threading.Tasks;
using App.Infrastructure.CrossCutting.Identity.Models;

namespace App.Infrastructure.CrossCutting.Identity.Interfaces
{
    /// <summary>
    /// Interface encapsulating methods for JWT (JSON Web Token) related operations.
    /// </summary>
    public interface IJwtFactory
    {
        /// <summary>
        /// Generate authentication result for the provided user login details.
        /// </summary>
        /// <param name="login">The details of the user trying to login.</param>
        /// <returns>A Task that represents the asynchronous operation. The task result returns an AuthenticationResult.</returns>
        Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(Login login);
        
        /// <summary>
        /// Retrieve principal information from the provided JWT.
        /// </summary>
        /// <param name="token">The JWT to extract the principal from.</param>
        /// <returns>A ClaimsPrincipal representing the user contained in the JWT.</returns>
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
