using Microsoft.EntityFrameworkCore;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Domain.ValueObjects;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Repositories
{
    public class ManagerRepository(AppDbContext ccntext) : BaseRepository<Manager>(ccntext), IManagerRepository
    {
        public async Task<IReadOnlyCollection<int>> ListAllIdsAsync()
        {
            return await Context.Set<Manager>()
                .Select(m => m.Id)
                .OrderByDescending(id => id)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<TaxNumber>> ListAllTaxNumbersAsync(bool sorted = true)
        {
            return await Context.Set<Manager>()
                .OrderByDescending(m => m.Name)
                .Select(m => m.TaxNumber)
                .ToListAsync();
        }
    }
}
