using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds
{
    public class ListAllManagerIdsIUseCase(IManagerRepository managerRepository) : IListAllManagerIdsIUseCase
    {
        private readonly IManagerRepository _managerRepository = managerRepository;

        public async Task Execute(ListAllManagerIdsInput input)
        {
            try
            {
                var managerIds = await _managerRepository.ListAllIdsAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
