using Microsoft.Extensions.Logging;
using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UseCases.Grapes.CalculateTotalPlantedAreaByGrape
{
    /// <summary>
    /// Calculate total planted area by grape use case
    /// </summary>
    /// <param name="logger">logger</param>
    /// <param name="grapeRepository">Repository</param>
    /// <param name="outputPort">outputPort</param>
    public sealed class CalculateTotalPlantedAreaByGrapeUseCase(
        ILogger<CalculateTotalPlantedAreaByGrapeUseCase> logger,
        IGrapeRepository grapeRepository,
        ICalculateTotalPlantedAreaByGrapeOutputPort outputPort) : ICalculateTotalPlantedAreaByGrapeUseCase
    {
        private readonly ILogger<CalculateTotalPlantedAreaByGrapeUseCase> _logger = logger;
        private readonly IGrapeRepository _grapeRepository = grapeRepository;
        private readonly ICalculateTotalPlantedAreaByGrapeOutputPort _outputPort = outputPort;

        /// <summary>
        /// Use case
        /// </summary>
        /// <param name="input">input</param>
        /// <returns></returns>
        public async Task Execute(CalculateTotalPlantedAreaByGrapeInput input)
        {
            try
            {
                _logger.LogInformation("Executing use case {UseCase}", 
                    nameof(CalculateTotalPlantedAreaByGrapeUseCase));

                var calculatedAreas = await _grapeRepository.GetTotalAreaByGrapeAsync();
                BuildOutput(calculatedAreas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, 
                    "An error has ocurred executing use case {UseCase}. Message {ex.Message}",
                    nameof(CalculateTotalPlantedAreaByGrapeUseCase),
                    ex.Message);

                throw;
            }
        }

        private void BuildOutput(Dictionary<string, int> calculatedAreas)
        {
            var output = new CalculateTotalPlantedAreaByGrapeOutput(calculatedAreas);
            _outputPort.StandardHandle(output);
        }
    }
}
