using System.ComponentModel.DataAnnotations;

namespace App.Infrastructure.CrossCutting.Identity.ViewModels.InputModels
{
    /// <summary>
    /// Represents the input model for user registration.
    /// </summary>
    public class RegisterUserInputModel
    {
        /// <summary>
        /// Gets or sets the email address of the user. EmailAddress attribute validates that the Email field is a valid email address.
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }
    
        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}