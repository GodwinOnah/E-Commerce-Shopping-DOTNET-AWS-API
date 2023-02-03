

using API.ApiErrorMiddleWares;
using API.ApiExtensions;
using API.AutoMapper;
using API.ErrorsHandlers;
using core.Entities.Identity;
using core.Interfaces;
using infrastructure.data;
using infrastructure.data.ProductsData;
using infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
builder.Services.AddDbContext<storeProducts>(
                x=>x.UseSqlite(builder.Configuration
                .GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions
                .Parse(builder.Configuration.GetConnectionString("Redis"),true);
                return ConnectionMultiplexer.Connect(configuration);
                });

builder.Services.AddIdentityService(builder.Configuration);

builder.Services.AddScoped<IBasket,BasketRepo>();
 //builder.Services.AddScoped<IProductInterface,ProductRepo>();
 builder.Services.AddScoped(typeof(IgenericProductInterface<>),(typeof(ProductGeneric<>)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProductProfile));
// builder.Services.AddCors(option=>
//                     {option.AddPolicy("CorsPolicy",
//                         policy=>
//                         {policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
//                                 });
//                             });var configuration

builder.Services.AddCors(option=>
                    option.AddPolicy("AllowAccess_To_API",
                        policy=>
                        policy.AllowAnyHeader().AllowAnyMethod()
                        .AllowCredentials().WithOrigins("http://localhost:4200").WithOrigins("http://localhost:7135/basket")
));

builder.Services.Configure<ApiBehaviorOptions>(option =>
        option.InvalidModelStateResponseFactory = actionContext => {

        var errors = actionContext.ModelState
        .Where(e => e.Value.Errors.Count > 0)
        .SelectMany(k => k.Value.Errors)
        .Select(i => i.ErrorMessage)
        .ToArray();



    var errorResponese = new ValidationErrors{

        Errors = errors
    };

    return new BadRequestObjectResult(errorResponese);
});

var app = builder.Build();

//this code creates the database


app.UseCors("AllowAccess_To_API");//cors

app.UseMiddleware<ErrorMiddleWare>(); //the cusomized middleware

app.UseSwagger();//available for both production and development mode
app.UseSwaggerUI();//available for both production and development mode

app.UseStatusCodePagesWithReExecute("/error/{0}");//use for redirecting error not handle by Error controllers

app.UseHttpsRedirection();

app.UseRouting();//for routing

app.UseStaticFiles();

// app.UseCors("CorsPolicy");


app.UseAuthentication();//configured in IdentityExtension class
app.UseAuthorization();

app.MapControllers();

using (var scope=app.Services.CreateScope()){//Contains all database configurations to create migrations

    var services=scope.ServiceProvider;

    var loggerFactory=services.GetRequiredService<ILoggerFactory>();
     var context=services.GetRequiredService<storeProducts>();
      var identityContext=services.GetRequiredService<MyAppIdentityDbContext>();
       var userManager=services.GetRequiredService<UserManager<AppUser>>();

    try{

        await context.Database.MigrateAsync();
         await identityContext.Database.MigrateAsync();
        await storeProductData.storeProductsAsync(context,loggerFactory);
        await IdentityUserData.SeedUserAsync(userManager);
    }

catch(Exception e){
        var logger=loggerFactory.CreateLogger<Program>();
        logger.LogError(e,"Migration error has occured");
    }

}


app.Run();
