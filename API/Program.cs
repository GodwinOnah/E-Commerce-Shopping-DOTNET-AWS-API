using API.ApiErrorMiddleWares;
using API.ApiExtensions;
using API.AutoMapper;
using API.ErrorsHandlers;
using infrastructure.data;
using infrastructure.data.ProductsData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using core.Entities.Interfaces;
using core;
using core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.Extensions.Logging;
using core.Entities.Identity;
using System;
using infrastructure.Identity;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

//Database configuration for PostgreSQL server
// builder.Services.AddDbContext<productContext>(
//                 x=>x.UseNpgsql(builder.Configuration
//                 .GetConnectionString("DefaultConnection"),
//                 x => x.MigrationsHistoryTable("_EFMigrationsHistory")));


var server = "DBServer" ?? "ms-sql-server";
var port = "DBPort" ?? "1443";
var user = "DBUser";
var password = "DBPassword";
var database = "Database";
var productcontextconnectionstring = $"Server={server},{port}; Initial catalogue={database}; User ID={user}; password={password}";
var userIdentityconnectionstring = $"Server={server},{port}; Initial catalogue={database}; User ID={user}; password={password}";

//Database configuration for SQL server
builder.Services.AddDbContext<productContext>(
                x=>x.UseSqlServer(productcontextconnectionstring,
                 options => options.EnableRetryOnFailure()
                ));

builder.Services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions
                             .Parse(builder.Configuration.GetConnectionString("Redis"),true);
                return ConnectionMultiplexer.Connect(configuration);
                });

 builder.Services.AddDbContext<UserIdentityDbContext>(
                x=>x.UseSqlServer(userIdentityconnectionstring,
                 options => options.EnableRetryOnFailure()
                ));

builder.Services.AddIdentityCore<User>(opt=>{})
                        .AddEntityFrameworkStores<UserIdentityDbContext>()
                        .AddSignInManager<SignInManager<User>>();

            
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(opt=>
                        {opt.TokenValidationParameters
                         = new TokenValidationParameters 
                                    {  ValidateIssuerSigningKey = true,
                                        IssuerSigningKey = 
                                                new SymmetricSecurityKey
                                                            (Encoding.UTF8.GetBytes(builder.Configuration["Token:key"])),
                                                            ValidateIssuer = true,
                                                            ValidIssuer = builder.Configuration["Token:Issuer"],
                                                            ValidateAudience = false                           
                        };});
                        
builder.Services.AddAuthorization();

builder.Services.AddSingleton<ICashing,CashingService>();
// builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddScoped<ITokenService,TokenServices>();
builder.Services.AddScoped<IBasket,BasketRepo>();
builder.Services.AddScoped<IProductDetails,ProductServices>();
builder.Services.AddScoped<IPaymentService,PaymentServices>();
builder.Services.AddScoped<IAdminOrder,AdminOrderService>();
builder.Services.AddScoped<IProductBrand,ProductBrandService>();
builder.Services.AddScoped<IProductType,ProductTypeService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IAdvert,AdvertService>();
builder.Services.AddScoped<IOrders,OrderServices>();
builder.Services.AddScoped(typeof(IgenericInterfaceRepository<>),(typeof(ProductGeneric<>)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(typeof(MappingProductProfile));


builder.Services.AddCors(option=>
                    option.AddPolicy("AllowAccess_To_API",
                        policy=>
                        policy.AllowAnyHeader().AllowAnyMethod()
                        .AllowCredentials().WithOrigins("https://blessingstoreapp.azurewebsites.net",
                        "https://localhost:4200")
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
app.UseMiddleware<ErrorMiddleWare>();
app.UseStatusCodePagesWithReExecute("/error/{0}");//use for redirecting error not handle by Error controllers
app.UseSwaggerDocumentation(); //the cusomized middleware from swagger extention created
// app.UseStaticFiles();//where to get static files, e.g images
app.UseDefaultFiles();
app.UseStaticFiles(
    new StaticFileOptions{
    FileProvider = new PhysicalFileProvider
    (Path.Combine(Directory.GetCurrentDirectory(),"files")), 
    RequestPath = "/files"
}
);

app.Use(async (context, next)=>{
    await next();
    if(context.Response.StatusCode == 400 &&
    !System.IO.Path.HasExtension(context.Request.Path.Value))
    {
        context.Request.Path = "/index.html";
        await next();
    }
});

app.UseCors("AllowAccess_To_API");//cors
app.UseHttpsRedirection();
app.UseRouting();//for routing
//configured in IdentityExtension class
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToController("index","fallback");
//this code creates the databases
using (var scope = app.Services.CreateScope()){//Contains all database configurations to create migrations
    var services = scope.ServiceProvider;
    var loggerFactory=services.GetRequiredService<ILoggerFactory>();
     var context=services.GetRequiredService<productContext>();
      var identityContext=services.GetRequiredService<UserIdentityDbContext>();
       var userManager=services.GetRequiredService<UserManager<User>>();
    try{
        await context.Database.MigrateAsync();
        await identityContext.Database.MigrateAsync();
        await StoreProductData.storeProductsAsync(context,loggerFactory);
        await IdentityUserData.SeedUserAsync(userManager);
    }

catch(Exception e){
        var logger=loggerFactory.CreateLogger<Program>();
        logger.LogError(e,"Migration error has occured again");
    }
}
app.Run();
