namespace App.Infrastructure.CrossCutting.Identity.ViewModels.OutputModels
{
    /// <summary>
    /// Represents the successful output model of authentication.
    /// </summary>
    public class AuthSuccessOutputModel
    {
        /// <summary>
        /// Gets or sets the JWT auth token.
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the expiration time in seconds of the token.
        /// It's Nullable to handle cases where token has no defined expiration.
        /// </summary>
        public double? ExpiresIn { get; set; }
    }
}