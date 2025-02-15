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
        }
    }
}
