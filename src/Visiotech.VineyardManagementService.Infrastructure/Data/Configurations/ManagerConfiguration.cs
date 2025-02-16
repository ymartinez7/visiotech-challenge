using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.TaxNumber)
                .HasMaxLength(50)
                .HasConversion(taxNumber => taxNumber.Value, value => new TaxNumber(value));

            builder.HasData(
                new Manager { Id = 1, TaxNumber = new TaxNumber("132254524"), Name = "Miguel Torres" },
                new Manager { Id = 2, TaxNumber = new TaxNumber("143618668"), Name = "Ana Martín" },
                new Manager { Id = 3, TaxNumber = new TaxNumber("78903228"), Name = "Carlos Ruiz" });
        }
    }
}
