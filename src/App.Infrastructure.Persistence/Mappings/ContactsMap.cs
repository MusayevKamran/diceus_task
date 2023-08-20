using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Persistence.Mappings;

public class ContactsMap: IEntityTypeConfiguration<Contacts>
{
    // The Configure method sets up the mapping configuration for the Contacts entity
    public void Configure(EntityTypeBuilder<Contacts> builder)
    {
        // Set the primary key for the Contacts entity to be the Id property
        builder.HasKey(c => c.Id); 

        // Map the UserId property of the Contacts entity to a column in the database
        builder.Property(x => x.UserId);

        // Map the Email property of the Contacts entity to a column in the database
        // Set the column type of the Email property to varchar(100)
        // Set maximum length of the Email property to 100 characters
        // The Email property is required
        builder.Property(c => c.Email)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
    }
}