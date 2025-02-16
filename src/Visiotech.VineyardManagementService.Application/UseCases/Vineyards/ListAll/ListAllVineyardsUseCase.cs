using Microsoft.Extensions.Logging;
using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UseCases.Vineyards.ListAll
{
    public class ListAllVineyardsUseCase(
        ILogger<ListAllVineyardsUseCase> logger,
        IVineyardRepository vineyardRepository,
        IListAllVineyardsOutputPort outputPort) : IListAllVineyardsUseCase
    {
        private readonly ILogger<ListAllVineyardsUseCase> _logger = logger;
        private readonly IVineyardRepository _vineyardRepository = vineyardRepository;
        private readonly IListAllVineyardsOutputPort _outputPort = outputPort;

        /// <summary>
        /// Use case
        /// </summary>
        /// <param name="input">input</param>
        /// <returns></returns>
        public async Task Execute(ListAllVineyardsInput input)
        {
            try
            {
                _logger.LogInformation("Executing use case {UseCase}",
                    nameof(ListAllVineyardsUseCase));

                var vineyards = await _vineyardRepository.GetVineyardsWithManagersAsync();
                BuildOutput(vineyards);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "An error has ocurred executing use case {UseCase}. Message {ex.Message}",
                    nameof(ListAllVineyardsUseCase),
                    ex.Message);

                throw;
            }
        }

        private void BuildOutput(Dictionary<string, List<string>> vineyards)
        {
            var output = new ListAllVineyardsOutput(vineyards);
            _outputPort.StandardHandle(output);
        }
    }
}
