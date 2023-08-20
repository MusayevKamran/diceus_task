using System.Collections.Generic;

namespace App.Infrastructure.CrossCutting.Identity.Models
{
    /// <summary>
    /// This class represents the result of an authentication attempt.
    /// </summary>
    public class AuthenticationResult
    {
        /// <summary>
        /// The LoginId of the authenticated user, or null if authentication was not successful.
        /// </summary>
        public string LoginId { get; set; }

        /// <summary>
        /// The authenticated token if authentication was successful, otherwise null.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Refresh token that can be used to obtain a new access token once the current token has expired.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// The lifetime in seconds of the access token. The client should be aware that the token can become invalid due to 
        /// change in user status, so should handle accordingly.
        /// </summary>
        public double? ExpiresIn { get; set; }

        /// <summary>
        /// Boolean to indicate if the authentication was successful or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// An enumerable collection of error messages, null or empty if the authentication was successful.
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
    }
}