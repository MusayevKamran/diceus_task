using App.Admin.Configurations;
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

builder.Services.AddAppDatabaseSetup(builder.Configuration);

builder.Services.AddIdentityDatabaseSetup(builder.Configuration);

// ASP.NET Identity Settings
builder.Services.AddIdentitySetup();

// MVC Settings
builder.Services.AddControllersWithViews();
            
builder.Services.AddRazorPages();

// .NET Native DI Abstraction
builder.Services.AddProjectSetup();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseDatabaseErrorPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();