using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Domain.Entities;

namespace Visiotech.VineyardManagementService.Domain.Repositories
{
    public interface IVineyardRepository : IBaseRepository<Vineyard>
    {
        Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync();
    }
}
