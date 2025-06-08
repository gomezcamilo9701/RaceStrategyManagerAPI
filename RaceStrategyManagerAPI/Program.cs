using Microsoft.EntityFrameworkCore;
using RaceStrategyManager.Application.Contract;
using RaceStrategyManager.Application.Implementation;
using RaceStrategyManager.Infrastructure;
using RaceStrategyManager.Infrastructure.Contract;
using RaceStrategyManager.Infrastructure.Implementation;
using RaceStrategyManagerAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<RaceStrategyManagerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IStrategyRepository, StrategyRepository>();
builder.Services.AddScoped<ITireRepository, TireRepository>();
builder.Services.AddScoped<IPilotRepository, PilotRepository>();

builder.Services.AddScoped<IStrategyService, StrategyService>();
builder.Services.AddScoped<IPilotService, PilotService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");

app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
