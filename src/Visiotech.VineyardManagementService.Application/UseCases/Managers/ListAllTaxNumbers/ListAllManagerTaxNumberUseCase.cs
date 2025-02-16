using Microsoft.Extensions.Logging;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers
{
    /// <summary>
    /// List all manager tax number use case
    /// </summary>
    /// <param name="logger">logger</param>
    /// <param name="managerRepository">repository</param>
    /// <param name="outputPort">outputPort</param>
    public class ListAllManagerTaxNumberUseCase(
        ILogger<ListAllManagerTaxNumberUseCase> logger,
        IManagerRepository managerRepository,
        IListAllManagerTaxNumbersOutputPort outputPort) : IListAllManagerTaxNumberUseCase
    {
        private readonly ILogger<ListAllManagerTaxNumberUseCase> _logger = logger;
        private readonly IManagerRepository _managerRepository = managerRepository;
        private readonly IListAllManagerTaxNumbersOutputPort _outputPort = outputPort;

        /// <summary>
        /// Use case
        /// </summary>
        /// <param name="input">input</param>
        /// <returns></returns>
        public async Task Execute(ListAllManagerTaxNumbersInput input)
        {
            try
            {
                _logger.LogInformation("Executing use case {UseCase}",
                    nameof(ListAllManagerTaxNumberUseCase));

                var managerTaxNumbers = await _managerRepository.ListAllTaxNumbersAsync(input.Sorted);
                BuildOutput(managerTaxNumbers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "An error has ocurred executing use case {UseCase}. Message {ex.Message}",
                    nameof(ListAllManagerTaxNumberUseCase),
                    ex.Message);

                throw;
            }
        }

        private void BuildOutput(IReadOnlyCollection<TaxNumber> managerTaxNumbers)
        {
            var output = new ListAllManagerTaxNumbersOutput(managerTaxNumbers);
            _outputPort.StandardHandle(output);
        }
    }
}
