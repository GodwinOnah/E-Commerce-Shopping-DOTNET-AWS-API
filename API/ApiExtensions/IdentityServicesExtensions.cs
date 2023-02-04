using core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.ApiExtensions
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityService(
            this IServiceCollection services,IConfiguration config)
        {

            services.AddDbContext<MyAppIdentityDbContext>(opt=>
            {
                opt.UseSqlite(config.GetConnectionString("IdentityConnection"), 
                b => b.MigrationsAssembly("infrastructure"));

               
            });


            services.AddIdentityCore<AppUser>(opt=>{


            })
            .AddEntityFrameworkStores<MyAppIdentityDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt=>{opt.TokenValidationParameters = new TokenValidationParameters {

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["Token:key"])),
                
                ValidateIssuer = true,
                ValidIssuer = config["Token:key"],
                ValidateAudience = false
                
                
            };});
            services.AddAuthorization();
           
                // Console.WriteLine( new SymmetricSecurityKey(
                //     Encoding.UTF8.GetBytes(config["Token:super secrete key"])));
            return services;
        }

    }
}