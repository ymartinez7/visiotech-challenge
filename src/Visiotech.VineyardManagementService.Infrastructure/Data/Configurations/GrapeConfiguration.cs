using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visiotech.VineyardManagementService.Domain.Entities;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Configurations
{
    public class GrapeConfiguration : IEntityTypeConfiguration<Grape>
    {
        public void Configure(EntityTypeBuilder<Grape> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.HasData(
                new Grape { Id = 1, Name = "Tempranillo" },
                new Grape { Id = 2, Name = "Albariño" },
                new Grape { Id = 3, Name = "Garnacha" });
        }
    }
}
