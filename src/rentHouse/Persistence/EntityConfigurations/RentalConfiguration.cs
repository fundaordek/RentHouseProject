using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("Rentals").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.CustomerId).HasColumnName("CustomerId");
        builder.Property(r => r.EstateId).HasColumnName("EstateId");
        builder.Property(r => r.RentalDate).HasColumnName("RentalDate");
        builder.Property(r => r.RentalEndDate).HasColumnName("RentalEndDate");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");
        builder.HasOne(ct => ct.Customer);
        builder.HasOne(e => e.Estate);

        builder.HasOne(r => r.Estate)
       .WithMany(e => e.Rentals)
       .HasForeignKey(r => r.EstateId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}