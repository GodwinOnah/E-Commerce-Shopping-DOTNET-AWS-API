
using core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.ApiErrorMiddleWares
{
    public static class UserManagerExtensions
    {

        public static async Task<User> FindUserByClaimPrincipleWIthAddress
        (this UserManager<User> userManager, ClaimsPrincipal user )
        {
            Console.WriteLine("\n\n\n\n"+user+55+"\n\n\n\n");
                var email = user.FindFirstValue(ClaimTypes.Email);
                return await userManager.Users.Include(x=>x.address)
                        .SingleOrDefaultAsync(x=>x.Email=="dan@gmail.com");
        }

        public static async Task<User> FindByEmailByClaimPrinciple
        (this UserManager<User> userManager, ClaimsPrincipal user )
        {
        //     var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //      Console.WriteLine("\n\n\n\n"+token+55+"\n\n\n\n");
        // var tokenClaims = new JwtSecurityToken(token.Replace("Bearer ", string.Empty));
        //  var email = tokenClaims.Payload["email"].ToString();

        var email = System.Security.Claims.ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email).Value;
        
            //  Console.WriteLine("\n\n\n\n"+user+55+"\n\n\n\n");
                //  var email = user.FindFirstValue(ClaimTypes.Email);
                //   Console.WriteLine("\n\n\n\n"+email+56+"\n\n\n\n");
                 // email is null but 'ClaimTypes.Email' has claims. I tried to console.log(user) but empty
                return await userManager.Users
                        .SingleOrDefaultAsync(x=>x.Email==email); //this work
        }        
    }
}