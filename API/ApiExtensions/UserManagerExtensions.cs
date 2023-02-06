using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.ApiErrorMiddleWares
{
    public static class UserManagerExtensions
    {

        public static async Task<User> FindUserByClaimPrincipleWIthAddress
        (this UserManager<User> userManager,ClaimsPrincipal user )
        {
                var email = user.FindFirstValue(ClaimTypes.Email);
                return await userManager.Users.Include(x=>x.address)
                        .SingleOrDefaultAsync(x=>x.Email==email);
        }

        public static async Task<User> FindByEmailByClaimPrinciple
        (this UserManager<User> userManager, ClaimsPrincipal user )
        {
                var email = user.FindFirstValue(ClaimTypes.Email);
                return await userManager.Users
                        .SingleOrDefaultAsync(x=>x.Email==email);
        }        
    }
}