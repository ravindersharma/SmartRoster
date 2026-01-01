using Serilog;
using SmartRoster.Api.Endpoints.Employees;
using SmartRoster.Application.DependencyInjection;
using SmartRoster.Infrastructure.DependencyInjection;
using SmartRoster.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// -----------------------------------------------------------------------------
// Logging (Serilog) from appsettings.json
// -----------------------------------------------------------------------------
builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration).WriteTo.Console());
// -----------------------------------------------------------------------------
// Core Application Layers
// -----------------------------------------------------------------------------
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString(AppContansts.DefaultConnectionString));
// -----------------------------------------------------------------------------
// OpenAPI / Swagger
// -----------------------------------------------------------------------------
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
}
// -----------------------------------------------------------------------------
// Build App
// -----------------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
// OpenAPI Only in Development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });
}
// -----------------------------------------------------------------------------
// MIDDLEWARE ORDER (DO NOT BREAK)
// -----------------------------------------------------------------------------
app.UseHttpsRedirection();

app.MapCreateEmployee();

app.Run();

public partial class Program { }