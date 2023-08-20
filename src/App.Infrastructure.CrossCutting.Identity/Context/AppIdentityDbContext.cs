using App.Infrastructure.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.CrossCutting.Identity.Context
{
    // Define a class that extends the IdentityDbContext provided by the ASP.NET Core Identity framework.
    // This class essentially represents your application's identity-related data context.
    public class AppIdentityDbContext : IdentityDbContext<Login>
    {
        // Add a constructor that accepts a DbContextOptions instance and passes it to the base class constructor.
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        // Define a DbSet for the RefreshTokens. This represents the RefreshTokens table in the database.
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
