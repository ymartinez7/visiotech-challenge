using Microsoft.Extensions.Logging;
using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds
{
    /// <summary>
    /// List all manager ids use case
    /// </summary>
    /// <param name="logger">logger</param>
    /// <param name="managerRepository">Repository</param>
    /// <param name="outputPort">outputPort</param>
    public sealed class ListAllManagerIdsUseCase(
        ILogger<ListAllManagerIdsUseCase> logger,
        IManagerRepository managerRepository,
        IListAllManagerIdsOutputPort outputPort) : IListAllManagerIdsUseCase
    {
        private readonly ILogger<ListAllManagerIdsUseCase> _logger = logger;
        private readonly IManagerRepository _managerRepository = managerRepository;
        private readonly IListAllManagerIdsOutputPort _outputPort = outputPort;

        /// <summary>
        /// Use case
        /// </summary>
        /// <param name="input">input</param>
        /// <returns></returns>
        public async Task Execute(ListAllManagerIdsInput input)
        {
            try
            {
                _logger.LogInformation("Executing use case {UseCase}",
                    nameof(ListAllManagerIdsUseCase));

                var managerIds = await _managerRepository.GetAllManagerIdsAsync();
                BuildOutput(managerIds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "An error has ocurred executing use case {UseCase}. Message {ex.Message}",
                    nameof(ListAllManagerIdsUseCase),
                    ex.Message);

                throw;
            }
        }

        private void BuildOutput(IReadOnlyCollection<int> managerIds)
        {
            var output = new ListAllManagerIdsOutput(managerIds);
            _outputPort.StandardHandle(output);
        }
    }
}
