using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RentTypeConfiguration : IEntityTypeConfiguration<RentType>
{
    public void Configure(EntityTypeBuilder<RentType> builder)
    {
        builder.ToTable("RentTypes").HasKey(rt => rt.Id);

        builder.Property(rt => rt.Id).HasColumnName("Id").IsRequired();
        builder.Property(rt => rt.Name).HasColumnName("Name");
        builder.Property(rt => rt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rt => rt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rt => rt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rt => !rt.DeletedDate.HasValue);
    }
}