using Microsoft.AspNetCore.Identity;

namespace App.Infrastructure.CrossCutting.Identity.Models
{
    /// <summary>
    /// Represents an Identity User for the application.
    /// Inherits from IdentityUser class provided by Microsoft.AspNetCore.Identity namespace.
    /// </summary>
    public class Login : IdentityUser
    {
        // This class can be expanded to include additional properties regarding the user,
        // if required, and they will be included in the users table.
    }
}
