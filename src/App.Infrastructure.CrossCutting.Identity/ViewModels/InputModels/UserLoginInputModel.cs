namespace App.Infrastructure.CrossCutting.Identity.ViewModels.InputModels
{
    /// <summary>
    /// Represents the input model for user login.
    /// </summary>
    public class UserLoginInputModel
    {
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}