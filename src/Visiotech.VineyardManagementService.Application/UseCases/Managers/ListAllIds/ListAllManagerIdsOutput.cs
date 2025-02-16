using Visiotech.VineyardManagementService.Application.Abstractions;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds
{
    /// <summary>
    /// Use case output
    /// </summary>
    /// <param name="managerIds"></param>
    public class ListAllManagerIdsOutput(IReadOnlyCollection<int> managerIds) : IUseCaseOutput
    {
        public IReadOnlyCollection<int> ManagerIdsList { get; private set; } = managerIds;
    }
}
