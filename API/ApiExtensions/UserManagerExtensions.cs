using System.Security.Claims;
using core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.ApiErrorMiddleWares
{
    public static class UserManagerExtensions
    {

        public static async Task<User> FindUserByClaimPrincipleWIthAddress
        (this UserManager<User> userManager, ClaimsPrincipal user )
        {
                var email = user.FindFirstValue(ClaimTypes.Email);
                // Console.WriteLine(email.Value+77);
                return await userManager.Users.Include(x=>x.address)
                        .SingleOrDefaultAsync(x=>x.Email==email);
        }

        public static async Task<User> FindByEmailByClaimPrinciple
        (this UserManager<User> userManager, ClaimsPrincipal user )
        {
                 var email = user.FindFirstValue(ClaimTypes.Email);
                Console.WriteLine("\n\n\n\n"+email+77+"\n\n\n\n");
                return await userManager.Users
                        .SingleOrDefaultAsync(x=>x.Email==email);
        }        
    }
}