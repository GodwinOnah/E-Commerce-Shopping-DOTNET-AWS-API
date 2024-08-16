// using core.Entities.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;

// namespace API.ApiExtensions
// {
//     public static class IdentityServicesExtensions
//     {
//         public static IServiceCollection AddIdentityService(
//             this IServiceCollection services,IConfiguration config)
//         {

//             // services.AddDbContext<UserIdentityDbContext>(opt=>
//             //             {
//             //                 opt.UseNpgsql(config.GetConnectionString("IdentityConnection"), 
//             //                 b => b.MigrationsAssembly("infrastructure"));                        
//             //             });

//             // services.AddDbContext<UserIdentityDbContext>(x=>
//             //     {x.UseSqlServer(config
//             //     .GetConnectionString("IdentityConnection"),
//             //     b => b.MigrationsAssembly("infrastructure")); 
                
//             //     });

//         //     public string server = "DBServer" ?? "ms-sql-server";
//         //     public string port = "DBPort" ?? "1443";
//         //     public string user = "DBUser";
//         //     public string password = "DBPassword";
//         //    public string database = "Database";


//             //Database configuration for SQL server
//             builder.Services.AddDbContext<UserIdentityDbContext>(
//                 x=>x.UseSqlServer($"Server=ms-sql-server,1433; Initial catalogue=database; User ID=Godwin; password=DBPassword",
//                  options => options.EnableRetryOnFailure()
//                 ));

//             services.AddIdentityCore<User>(opt=>{})
//                         .AddEntityFrameworkStores<UserIdentityDbContext>()
//                         .AddSignInManager<SignInManager<User>>();

            
//             services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                         .AddJwtBearer(opt=>
//                         {opt.TokenValidationParameters
//                          = new TokenValidationParameters 
//                          {  ValidateIssuerSigningKey = true,
//                             IssuerSigningKey = 
//                             new SymmetricSecurityKey
//                             (Encoding.UTF8.GetBytes(config["Token:key"])),
//                             ValidateIssuer = true,
//                             ValidIssuer = config["Token:Issuer"],
//                             ValidateAudience = false                           
//                         };});
                        
//             services.AddAuthorization();
                    
//              return services;
//         }

//     }
// }