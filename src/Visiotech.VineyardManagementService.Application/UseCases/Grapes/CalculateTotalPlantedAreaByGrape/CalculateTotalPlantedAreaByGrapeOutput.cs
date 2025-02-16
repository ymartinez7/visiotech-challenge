using Visiotech.VineyardManagementService.Application.Abstractions;

namespace Visiotech.VineyardManagementService.Application.UseCases.Grapes.CalculateTotalPlantedAreaByGrape
{
    /// <summary>
    /// Use case output
    /// </summary>
    /// <param name="calculatedAreas">calculatedAreas</param>
    public sealed class CalculateTotalPlantedAreaByGrapeOutput(Dictionary<string, int> calculatedAreas) : IUseCaseOutput
    {
        public Dictionary<string, int> CalculatedAreas { get; private set; } = calculatedAreas;
    }
}
