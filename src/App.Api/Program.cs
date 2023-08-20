using App.Api.Configurations;
using App.Infrastructure.CrossCutting.Identity.Configurations;
using App.Infrastructure.CrossCutting.IoC;
using App.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();


// Setting DBContexts
builder.Services.AddAppDatabaseSetup(builder.Configuration);
builder.Services.AddIdentityDatabaseSetup(builder.Configuration);

// WebAPI Config
builder.Services.AddControllers();
            
// Identity Settings
builder.Services.AddIdentitySetup(builder.Configuration);

// Project Settings
builder.Services.AddProjectSetup();

builder.Services.AddSwaggerSetup();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwaggerSetup();

app.Run();