using Microsoft.EntityFrameworkCore;
using WisconsinGacha.Database;
using WisconsinGacha.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

builder.Services.AddScoped<ICardsManager, CardsManager>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();