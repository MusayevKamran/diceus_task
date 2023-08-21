using System;
using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Mappings
{
    // The UserMap class that configures the properties of the User entity.
    public class UserMap : IEntityTypeConfiguration<User>
    {
        // Configure the UserMap class.
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            // Configured the Id property of the User entity as the primary key.
            builder.HasKey(property => property.Id);
            builder.Property(property => property.Id).ValueGeneratedOnAdd();

            // Configured the LoginId property of the User entity.
            builder.Property(property => property.LoginId);

            // Configured the Email property of the User entity 
            // with unique characteristics and requirements.
            builder.Property(property => property.Email)
                .HasColumnType("varchar(100)") // Defined the column type in the database.
                .HasMaxLength(100) // Set the maximum length for Email.
                .IsRequired(); // Set the Email property to be required.
        }
    }
}
