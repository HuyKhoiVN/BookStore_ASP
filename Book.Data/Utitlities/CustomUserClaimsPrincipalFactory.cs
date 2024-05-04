using Books.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Utitlities
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor
            ) : base( userManager, roleManager, optionsAccessor )
        {
            
        }

        protected override async Task<ClaimsIdentity> GenerateClaimAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync( user );
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName ?? ""));
            return identity;
        }
    }
}
