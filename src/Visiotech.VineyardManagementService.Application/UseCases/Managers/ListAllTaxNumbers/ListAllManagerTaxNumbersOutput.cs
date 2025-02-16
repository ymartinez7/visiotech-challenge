using Visiotech.VineyardManagementService.Application.Abstractions;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers
{
    /// <summary>
    /// Use case output
    /// </summary>
    public sealed class ListAllManagerTaxNumbersOutput : IUseCaseOutput
    {
        public ListAllManagerTaxNumbersOutput(IReadOnlyCollection<TaxNumber> managerTaxNumbers)
        {
            foreach (TaxNumber taxNumber in managerTaxNumbers)
            {
                ManagerTaxNumbersList.Add(taxNumber.Value);
            }
        }

        public List<string> ManagerTaxNumbersList { get; private set; } = [];
    }
}
