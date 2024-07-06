using Microsoft.EntityFrameworkCore;
using WisconsinGacha.Database;
using WisconsinGacha.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddScoped<ICardsManager, CardsManager>();
builder.Services.AddScoped<IBannersManager, BannersManager>();


var app = builder.Build();

app.UseCors();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();