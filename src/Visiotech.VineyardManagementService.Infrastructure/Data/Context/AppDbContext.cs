using Microsoft.EntityFrameworkCore;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Infrastructure.Data.Configurations;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Grape> Grapes { get; set; }
        public DbSet<Vineyard> Vineyards { get; set; }
        public DbSet<Parcel> Parcels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.ApplyConfiguration(new GrapeConfiguration());
            modelBuilder.ApplyConfiguration(new VineyardConfiguration());
            modelBuilder.ApplyConfiguration(new ParcelConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
