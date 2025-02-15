using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers
{
    public class ListAllManagerTaxNumberUseCase(IManagerRepository managerRepository) : IListAllManagerTaxNumberUseCase
    {
        private readonly IManagerRepository _managerRepository = managerRepository;

        public async Task Execute(ListAllManagerTaxNumbersInput input)
        {
            try
            {
                var managerIds = await _managerRepository.ListAllTaxNumbersAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
