using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace App.Infrastructure.CrossCutting.Identity.Authorization.Claims
{
    // This class is named ClaimsRequirementHandler and it implements the abstract class AuthorizationHandler 
    // with a ClaimRequirement object. This class handles the authorization process of certain claims.
    public class ClaimsRequirementHandler : AuthorizationHandler<ClaimRequirement>
    {
        // This method is used to handle the requirement asynchronously and checks context and claim requirement.
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ClaimRequirement requirement)
        {
            var claim = context.User.Claims.FirstOrDefault(c => c.Type == requirement.ClaimName);
            
            if (claim != null && claim.Value.Contains(requirement.ClaimValue))
            {
                context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }
    }
}