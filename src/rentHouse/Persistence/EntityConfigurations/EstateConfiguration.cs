using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EstateConfiguration : IEntityTypeConfiguration<Estate>
{
    public void Configure(EntityTypeBuilder<Estate> builder)
    {
        builder.ToTable("Estates").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.Area).HasColumnName("Area");
        builder.Property(e => e.RoomCount).HasColumnName("RoomCount");
        builder.Property(e => e.Floor).HasColumnName("Floor");
        builder.Property(e => e.BuildingFloor).HasColumnName("BuildingFloor");
        builder.Property(e => e.HeatingType).HasColumnName("HeatingType");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
        builder.HasOne(b => b.Business);
        builder.HasOne(ct => ct.Customer);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}