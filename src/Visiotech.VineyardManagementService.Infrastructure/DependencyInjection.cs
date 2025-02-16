using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;
using Visiotech.VineyardManagementService.Infrastructure.Data.Repositories;

namespace Visiotech.VineyardManagementService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddPersistence(services, configuration);

            return services;
        }

        private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IGrapeRepository, GrapeRepository>();
            services.AddScoped<IVineyardRepository, VineyardRepository>();
        }
    }
}
