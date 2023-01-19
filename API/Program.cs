

using API.AutoMapper;
using core.Interfaces;
using infrastructure.data;
using infrastructure.data.ProductsData;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
builder.Services.AddDbContext<storeProducts>(
                x=>x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration =ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"),true);
                return ConnectionMultiplexer.Connect(configuration);
                });
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
                        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200")
));



var app = builder.Build();

//this code creates the database

using (var scope=app.Services.CreateScope()){

    var services=scope.ServiceProvider;

    var loggerFactory=services.GetRequiredService<ILoggerFactory>();
     var context=services.GetRequiredService<storeProducts>();

    try{

        await context.Database.MigrateAsync();

        await storeProductData.storeProductsAsync(context,loggerFactory);
    }

    catch(Exception e){

        var logger=loggerFactory.CreateLogger<Program>();

        logger.LogError(e,"Migration error has occured");
    }

}
app.UseCors("AllowAccess_To_API");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

// app.UseCors("CorsPolicy");



app.UseAuthorization();

app.MapControllers();




app.Run();
