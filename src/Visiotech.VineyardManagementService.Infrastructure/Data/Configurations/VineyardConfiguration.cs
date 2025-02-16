using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visiotech.VineyardManagementService.Domain.Entities;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Configurations
{
    public class VineyardConfiguration : IEntityTypeConfiguration<Vineyard>
    {
        public void Configure(EntityTypeBuilder<Vineyard> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.HasData(
                new Vineyard { Id = 1, Name = "Viña Esmeralda" },
                new Vineyard { Id = 2, Name = "Bodegas Bilbaínas" });
        }
    }
}
