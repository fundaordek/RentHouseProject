using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BusinessConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.ToTable("Businesses").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name");
        builder.Property(b => b.AuthorizedPerson).HasColumnName("AuthorizedPerson");
        builder.Property(b => b.Address).HasColumnName("Address");
        builder.Property(b => b.Phone).HasColumnName("Phone");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
     
        builder.HasMany(b => b.Estates);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}