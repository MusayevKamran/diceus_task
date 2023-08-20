using App.Domain.Models;
using App.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence.Context
{
    /// <summary>
    /// Defines the entity framework data context for the application
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">An object that is passed to the base DbContext options</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the collection of Users in the database.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the collection of Contacts in the database.
        /// </summary>
        public DbSet<Contacts> Contacts { get; set; }

        /// <summary>
        /// Apply configutations to the model builder. This method is called when the model for a derived context has been initialized, 
        /// but before the model has been locked down and used to initialize the context.
        /// </summary>
        /// <param name="modelBuilder">An instance of <see cref="ModelBuilder"/> to apply configurations</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configuration for User Entities
            modelBuilder.ApplyConfiguration(new UserMap());

            // Apply configuration for Contact Entities
            modelBuilder.ApplyConfiguration(new ContactsMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
