using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Domain.Repositories
{
    public interface IManagerRepository : IBaseRepository<Manager>
    {
        Task<IReadOnlyCollection<int>> ListAllIdsAsync();
        Task<IReadOnlyCollection<TaxNumber>> ListAllTaxNumbersAsync(bool sorted = true);
    }
}
