using Visiotech.VineyardManagementService.Application.Abstractions;

namespace Visiotech.VineyardManagementService.Application.UseCases.Vineyards.ListAll
{
    /// <summary>
    /// Use case output
    /// </summary>
    /// <param name="vineyards">vineyards</param>
    public class ListAllVineyardsOutput(Dictionary<string, List<string>> vineyards) : IUseCaseOutput
    {
        public Dictionary<string, List<string>> Vineyards { get; private set; } = vineyards;
    }
}
