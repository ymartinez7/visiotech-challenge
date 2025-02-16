using Visiotech.VineyardManagementService.Application.Abstractions;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers
{
    /// <summary>
    /// Use case input
    /// </summary>
    /// <param name="sorted"></param>
    public sealed class ListAllManagerTaxNumbersInput(bool sorted) : IUseCaseInput
    {
        public bool Sorted { get; private set; } = sorted;
    }
}
