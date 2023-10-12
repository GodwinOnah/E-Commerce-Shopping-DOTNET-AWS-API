using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using core.Entities.Identity;

namespace API.ApiErrorMiddleWares
{
    public static class UserManagerExtensions
    {
        public static async Task<User> FindByEmailByClaimPrinciple
        (this UserManager<User> userManager, ClaimsPrincipal user )
        {

            if (user == null)
                throw new ArgumentNullException(nameof(user));
                return await userManager.Users
                        .SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email)); //this work
        }    

        public static async Task<User> FindUserByClaimsPrincipleWithAddress
        (this UserManager<User> userManager, ClaimsPrincipal user )
        {

            if (user == null)
                throw new ArgumentNullException(nameof(user));
                return await userManager.Users.Include(x => x.address)
                        .SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email)); //this work
        }        
    }
}