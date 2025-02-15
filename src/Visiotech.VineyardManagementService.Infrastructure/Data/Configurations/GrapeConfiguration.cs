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
        }
    }
}
