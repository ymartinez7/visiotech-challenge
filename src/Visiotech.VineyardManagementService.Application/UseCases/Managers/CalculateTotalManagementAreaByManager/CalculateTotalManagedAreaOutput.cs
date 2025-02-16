using Visiotech.VineyardManagementService.Application.Abstractions;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager
{
    /// <summary>
    /// Use case output
    /// </summary>
    /// <param name="calculatedAreas">calculatedAreas</param>
    public sealed class CalculateTotalManagedAreaOutput(Dictionary<string, int> calculatedAreas) : IUseCaseOutput
    {
        public Dictionary<string, int> Areas { get; private set; } = calculatedAreas;
    }
}
