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

            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.YearPlanted)
                .IsRequired()
                .HasConversion(yearPlanted => yearPlanted.Value, value => new YearPlanted(value));

            builder.Property(m => m.Area)
                .IsRequired()
                .HasConversion(area => area.Value, value => new Area(value));

            builder.HasOne(p => p.Manager)
                .WithMany(m => m.Parcels)
                .HasForeignKey(p => p.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Vineyard)
                .WithMany(v => v.Parcels)
                .HasForeignKey(p => p.VineyardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Grape)
                .WithMany(g => g.Parcels)
                .HasForeignKey(p => p.GrapeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Parcel { Id = 1, ManagerId= 1, VineyardId = 1, GrapeId = 1, YearPlanted = new YearPlanted(2019), Area =  new Area(1500) },
                new Parcel { Id = 2, ManagerId = 2, VineyardId = 2, GrapeId = 2, YearPlanted = new YearPlanted(2021), Area = new Area(9000) },
                new Parcel { Id = 3, ManagerId= 3, VineyardId = 1, GrapeId = 3, YearPlanted = new YearPlanted(2020), Area = new Area(3000) },
                new Parcel { Id = 4, ManagerId= 1, VineyardId = 2, GrapeId = 1, YearPlanted = new YearPlanted(2020), Area = new Area(2000) },
                new Parcel { Id = 5, ManagerId= 3, VineyardId = 2, GrapeId = 3, YearPlanted = new YearPlanted(2021), Area = new Area(1000) });
        }
    }
}
