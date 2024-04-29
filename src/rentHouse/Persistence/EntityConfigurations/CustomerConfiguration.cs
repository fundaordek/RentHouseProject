using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(ct => ct.Id);

        builder.Property(ct => ct.Id).HasColumnName("Id").IsRequired();
        builder.Property(ct => ct.FirstName).HasColumnName("FirstName");
        builder.Property(ct => ct.LastName).HasColumnName("LastName");
        builder.Property(ct => ct.HomePhone).HasColumnName("HomePhone");
        builder.Property(ct => ct.CellPhone).HasColumnName("CellPhone");
        builder.Property(ct => ct.Email).HasColumnName("Email");
        builder.Property(ct => ct.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ct => ct.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ct => ct.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ct => !ct.DeletedDate.HasValue);
    }
}