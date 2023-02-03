using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API.ApiErrorMiddleWares;
using API.AutoMapper;
using API.ErrorsHandlers;
using core.Interfaces;
using infrastructure.data;
using infrastructure.data.ProductsData;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Microsoft.AspNetCore.Identity;

namespace API.ApiExtensions
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration config)
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

            services.AddAuthentication();
            services.AddAuthorization();
           

            return services;
        }

    }
}