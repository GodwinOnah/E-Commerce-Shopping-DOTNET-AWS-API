

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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using infrastructure.Services;
using core;
using core.Entities.Interfaces;

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
builder.Services.AddSwaggerDocumentation();
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddScoped<IBasket,BasketRepo>();
builder.Services.AddSingleton<ICashing,CashingService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IOrders,OrderServices>();
builder.Services.AddScoped<IPaymentService,PaymentServices>();
 //builder.Services.AddScoped<IProductInterface,ProductRepo>();
 builder.Services.AddScoped(typeof(IgenericInterfaceRepository<>),(typeof(ProductGeneric<>)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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


app.UseMiddleware<ErrorMiddleWare>();

app.UseStatusCodePagesWithReExecute("/error/{0}");//use for redirecting error not handle by Error controllers

app.UseSwaggerDocumentation(); //the cusomized middleware from swagger extention created

app.UseStaticFiles();

app.UseCors("AllowAccess_To_API");//cors

app.UseHttpsRedirection();

app.UseRouting();//for routing



//configured in IdentityExtension class
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//this code creates the databases
using (var scope=app.Services.CreateScope()){//Contains all database configurations to create migrations

    var services=scope.ServiceProvider;

    var loggerFactory=services.GetRequiredService<ILoggerFactory>();
     var context=services.GetRequiredService<storeProducts>();
      var identityContext=services.GetRequiredService<UserIdentityDbContext>();
       var userManager=services.GetRequiredService<UserManager<User>>();

    try{

        await context.Database.MigrateAsync();
         await identityContext.Database.MigrateAsync();
        await storeProductData.storeProductsAsync(context,loggerFactory);
        await IdentityUserData.SeedUserAsync(userManager);
    }

catch(Exception e){
        var logger=loggerFactory.CreateLogger<Program>();
        logger.LogError(e,"Migration error has occured");
    }}

app.Run();
