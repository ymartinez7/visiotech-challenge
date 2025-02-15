using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Configurations
{
    public class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(m => m.YearPlanted)
                .HasConversion(yearPlanted => yearPlanted.Value, value => new YearPlanted(value));

            builder.Property(m => m.Area)
                .HasConversion(area => area.Value, value => new Area(value));

            builder.HasOne(m => m.Manager)
                .WithOne(p => p.Parcel)
                .HasForeignKey<Parcel>(p => p.ManagerId);

            builder.HasOne(v => v.Vineyard)
               .WithOne(p => p.Parcel)
               .HasForeignKey<Parcel>(p => p.VineyardId);

            builder.HasOne(g => g.Grape)
                .WithOne(p => p.Parcel)
                .HasForeignKey<Parcel>(p => p.GrapeId);
        }
    }
}
