using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MarketPlace.Pro.Api.Security
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasScopeRequirement requirement)
        {
            // Check that the token comes from the trusted issuer
            if (!context.User.HasClaim(c =>
                c.Type == "scope" && c.Issuer == requirement.Issuer))
            {
                return Task.CompletedTask;
            }

            // Retrieve the scopes from the token
            var scopes = context.User
                .FindFirst(c =>
                    c.Type == "scope" && c.Issuer == requirement.Issuer)
                ?.Value.Split(' ');

            // Check whether the required permission exists
            if (scopes?.Any(s => s == requirement.Scope) == true)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}