using System.Collections.Generic;

namespace App.Infrastructure.CrossCutting.Identity.ViewModels.OutputModels
{
    /// <summary>
    /// Represents the output model for authorization failure.
    /// </summary>
    public class AuthFailedOutputModel
    {
        /// <summary>
        /// Gets or sets the collection of error messages.
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
    }
}