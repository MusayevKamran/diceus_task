using System;

namespace App.Infrastructure.CrossCutting.Identity.Authorization.JWT
{
    /// <summary>
    /// Class to handle the settings of JWT.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Gets or sets the secret key used for token generation and validation.
        /// </summary>
        public string Secret { get; set; }
        
        /// <summary>
        /// Gets or sets the lifetime of the token after its creation.
        /// </summary>
        public TimeSpan TokenLifetime { get; set; } 
    }
}
