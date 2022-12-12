
using core.Interfaces;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
builder.Services.AddDbContext<storeProducts>(
 x=>x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<DbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IProductInterface,ProductRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//this code created database
using (var scope=app.Services.CreateScope()){

    var services=scope.ServiceProvider;

    var loggerFactory=services.GetRequiredService<ILoggerFactory>();

    try{

        var context=services.GetRequiredService<storeProducts>();

        await context.Database.MigrateAsync();
    }

    catch(Exception e){

        var logger=loggerFactory.CreateLogger<Program>();

        logger.LogError(e,"Migration error occured");
    }

}

app.Run();
