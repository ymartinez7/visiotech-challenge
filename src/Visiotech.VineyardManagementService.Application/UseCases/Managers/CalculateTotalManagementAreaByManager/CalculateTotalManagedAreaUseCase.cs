using Microsoft.Extensions.Logging;
using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager
{
    /// <summary>
    /// Calculate total managed area use case
    /// </summary>
    /// <param name="logger">logger</param>
    /// <param name="managerRepository"></param>
    /// <param name="outputPort"></param>
    public sealed class CalculateTotalManagedAreaUseCase(
        ILogger<CalculateTotalManagedAreaUseCase> logger,
        IManagerRepository managerRepository,
        ICalculateTotalManagedAreaOutputPort outputPort) 
        : ICalculateTotalManagedAreaUseCase
    {
        private readonly ILogger<CalculateTotalManagedAreaUseCase> _logger = logger;
        private readonly IManagerRepository _managerRepository = managerRepository;
        private readonly ICalculateTotalManagedAreaOutputPort _outputPort = outputPort;

        /// <summary>
        /// Use case
        /// </summary>
        /// <param name="input">input</param>
        /// <returns></returns>
        public async Task Execute(CalculateTotalManagedAreaInput input)
        {
            try
            {
                _logger.LogInformation("Executing use case {UseCase}",
                    nameof(CalculateTotalManagedAreaUseCase));

                var calculatedAreas = await _managerRepository.GetTotalAreaByManagerAsync();
                BuildOutput(calculatedAreas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "An error has ocurred executing use case {UseCase}. Message {ex.Message}",
                    nameof(CalculateTotalManagedAreaUseCase),
                    ex.Message);

                throw;
            }
        }

        private void BuildOutput(Dictionary<string, int> calculatedAreas)
        {
            var output = new CalculateTotalManagedAreaOutput(calculatedAreas);
            _outputPort.StandardHandle(output);
        }
    }
}
