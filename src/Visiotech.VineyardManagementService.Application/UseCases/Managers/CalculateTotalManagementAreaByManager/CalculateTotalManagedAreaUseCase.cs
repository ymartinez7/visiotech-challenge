using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager
{
    public class CalculateTotalManagedAreaUseCase(IManagerRepository managerRepository) : ICalculateTotalManagedAreaUseCase
    {
        public Task Execute(CalculateTotalManagedAreaInput input)
        {
            throw new NotImplementedException();
        }
    }
}
