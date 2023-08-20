namespace App.Infrastructure.CrossCutting.Identity.ViewModels.InputModels
{
    /// <summary>
    /// Represents the input model for refresh token.
    /// </summary>
    public class RefreshTokenInputModel
    {
        /// <summary>
        /// Gets or sets the JWT token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the refresh token used to get a new JWT token.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}