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

            builder.Property(m => m.TaxNumber)
                .HasMaxLength(50)
                .HasConversion(taxNumber => taxNumber.Value, value => new TaxNumber(value));
        }
    }
}
