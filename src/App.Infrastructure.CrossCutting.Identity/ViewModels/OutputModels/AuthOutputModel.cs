namespace App.Infrastructure.CrossCutting.Identity.ViewModels.OutputModels
{
    /// <summary>
    /// Represents the AuthOutputModel class.
    /// </summary>
    /// <typeparam name="T">The type of the AuthToken.</typeparam>
    public class AuthOutputModel<T> {
        
        /// <summary>
        /// Initializes a new instance of the AuthOutputModel class.
        /// </summary>
        public AuthOutputModel() { }

        /// <summary>
        /// Initializes a new instance of the AuthOutputModel class with a specified response.
        /// </summary>
        /// <param name="response">The response to set as the AuthToken.</param>
        public AuthOutputModel(T response) {
            AuthToken = response;
        }

        /// <summary>
        /// Gets or sets the AuthToken.
        /// </summary>
        public T AuthToken { get; set; }
    }
}