using Visiotech.VineyardManagementService.Application.Abstractions;
using Visiotech.VineyardManagementService.Domain.Models;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds
{
    /// <summary>
    /// Use case output
    /// </summary>
    /// <param name="managerIds"></param>
    public sealed class ListAllManagerIdsOutput(IEnumerable<ManagerIdInfo> managerIds) : IUseCaseOutput
    {
        public IEnumerable<ManagerIdInfo> ManagerIdsList { get; private set; } = managerIds;
    }
}
