using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.Models;

namespace Visiotech.VineyardManagementService.Domain.Repositories
{
    public interface IManagerRepository : IBaseRepository<Manager>
    {
        Task<IEnumerable<ManagerIdInfo>> GetAllManagerIdsAsync();
        Task<IEnumerable<ManagerTaxNumberInfo>> GetAllManagerTaxNumbersAsync(bool sorted);
        Task<Dictionary<string, int>> GetTotalManagementAreaByManagerAsync();
    }
}
