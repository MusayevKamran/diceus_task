using System.Threading.Tasks;
using App.Infrastructure.CrossCutting.Identity.Models;

namespace App.Infrastructure.CrossCutting.Identity.Interfaces
{
    /// <summary>
    /// Interface for Authentication/Authorization services.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Registers a new account with the specified email and password.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>An AuthenticationResult indicating the result of the registration.</returns>
        Task<AuthenticationResult> RegisterAsync(string email, string password);

        /// <summary>
        /// Authenticates the user with the given user credentials.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>An AuthenticationResult indicating the result of the login.</returns>
        Task<AuthenticationResult> LoginAsync(string email, string password);

        /// <summary>
        /// Refreshes the authentication token.
        /// </summary>
        /// <param name="token">The current authentication token.</param>
        /// <param name="refreshToken">The current refresh token.</param>
        /// <returns>An AuthenticationResult indicating the result of the token refresh.</returns>
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        
        /// <summary>
        /// Refreshes the authentication token.
        /// </summary>
        /// <param name="token">The current authentication token.</param>
        /// <param name="refreshToken">The current refresh token.</param>
        /// <returns>An AuthenticationResult indicating the result of the token refresh.</returns>
        Task<AuthenticationResult> GetTokenAsync();
    }
}
