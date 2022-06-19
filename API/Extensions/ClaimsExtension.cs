using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Owin.Security;
using Microsoft.AspNetCore.Identity;
using Domain.Models.Entities.Identity;

namespace API.Extensions
{
    public static class ClaimsExtension
    {
        public static void AddUpdateClaim(this IPrincipal currentPrincipal,
            string value,
            ref SignInManager<User> _signInManager)
        {
            if (currentPrincipal.Identity is not ClaimsIdentity identity)
                return;

            // check for existing claim and remove it
            var existingClaim = identity.FindFirst(ClaimTypes.Email);
            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            // add new claim
            identity.AddClaim(new Claim(ClaimTypes.Email, value));
        }

        public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
        {
            if (currentPrincipal.Identity is not ClaimsIdentity identity)
                return null;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == key);
            return claim.Value;
        }
    }
}
