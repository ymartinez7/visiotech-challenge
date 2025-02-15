using Microsoft.Extensions.DependencyInjection;
using Visiotech.VineyardManagementService.Application.UseCases.Grapes.CalculateTotalPlantedAreaByGrape;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers;
using Visiotech.VineyardManagementService.Application.UseCases.Vineyards.ListAll;

namespace Visiotech.VineyardManagementService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICalculateTotalPlantedAreaByGrapeUseCase, CalculateTotalPlantedAreaByGrapeUseCase>();

            services.AddScoped<ICalculateTotalManagedAreaUseCase, CalculateTotalManagedAreaUseCase>();
            services.AddScoped<IListAllManagerIdsIUseCase, ListAllManagerIdsIUseCase>();
            services.AddScoped<IListAllManagerTaxNumberUseCase, ListAllManagerTaxNumberUseCase>();

            services.AddScoped<IListAllVineyardsUseCase, ListAllVineyardsUseCase>();

            return services;
        }
    }
}
