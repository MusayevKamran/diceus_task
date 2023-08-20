using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infrastructure.CrossCutting.Identity.Models
{
    // Represents a refresh token in the identity system
    public class RefreshToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // This is the token itself, a unique identifier
        public string Token { get; set; }

        // JWT ID associated with the refresh token
        public string JwtId { get; set; }

        // The date when the refresh token was created
        public DateTime CreationDate { get; set; }

        // The date when the refresh token will expire
        public DateTime ExpiryDate { get; set; }

        // A flag indicating whether the refresh token has been used
        public bool Used { get; set; }

        // A flag indicating whether the refresh token has been invalidated
        public bool Invalidated { get; set; }

        // The ID of the login associated with the refresh token
        public string LoginId { get; set; }

        // A navigation property for the Login associated with the refresh token
        [ForeignKey(nameof(LoginId))]
        public Login Login { get; set; }
    }
}
