using Visiotech.VineyardManagementService.Api.Handlers.Grapes.CalculateTotalPlantedAreaByGrape;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.CalculateTotalManagementAreaByManager;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllIds;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllTaxNumbers;
using Visiotech.VineyardManagementService.Api.Handlers.Vineyards.ListAll;
using Visiotech.VineyardManagementService.Application.UseCases.Grapes.CalculateTotalPlantedAreaByGrape;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers;
using Visiotech.VineyardManagementService.Application.UseCases.Vineyards.ListAll;

namespace Visiotech.VineyardManagementService.Api.Extensions
{
    public static class PresenterExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddSingleton<CalculateTotalPlantedAreaByGrapePresenter>();
            services.AddSingleton<CalculateTotalManagementAreaByManagerPresenter>();
            services.AddSingleton<ListAllManagerIdsPresenter>();
            services.AddSingleton<ListAllManagerTaxNumberPresenter>();
            services.AddSingleton<ListAllVineyardsPresenter>();

            services.AddSingleton<ICalculateTotalPlantedAreaByGrapeOutputPort>(provider => provider.GetRequiredService<CalculateTotalPlantedAreaByGrapePresenter>());
            services.AddSingleton<ICalculateTotalManagedAreaOutputPort>(provider => provider.GetRequiredService<CalculateTotalManagementAreaByManagerPresenter>());
            services.AddSingleton<IListAllManagerIdsOutputPort>(provider => provider.GetRequiredService<ListAllManagerIdsPresenter>());
            services.AddSingleton<IListAllManagerTaxNumbersOutputPort>(provider => provider.GetRequiredService<ListAllManagerTaxNumberPresenter>());
            services.AddSingleton<IListAllVineyardsOutputPort>(provider => provider.GetRequiredService<ListAllVineyardsPresenter>());

            return services;
        }
    }
}
