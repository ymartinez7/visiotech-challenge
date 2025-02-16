using Visiotech.VineyardManagementService.Application.Abstractions;
using Visiotech.VineyardManagementService.Domain.Models;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers
{
    /// <summary>
    /// Use case output
    /// </summary>
    public sealed class ListAllManagerTaxNumbersOutput(IEnumerable<ManagerTaxNumberInfo> managerTaxNumbers) : IUseCaseOutput
    {
        public IEnumerable<ManagerTaxNumberInfo> ManagerTaxNumbersList { get; private set; } = managerTaxNumbers;
    }
}
