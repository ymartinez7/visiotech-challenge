using Microsoft.EntityFrameworkCore;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.Models;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Repositories
{
    public sealed class ManagerRepository(AppDbContext context) : BaseRepository<Manager>(context), IManagerRepository
    {
        public async Task<IEnumerable<ManagerIdInfo>> GetAllManagerIdsAsync()
        {
            return await Context.Set<Manager>()
                .OrderBy(id => id)
                .Select(m => new ManagerIdInfo(m.Id, m.Name))
                .ToListAsync();
        }

        public async Task<IEnumerable<ManagerTaxNumberInfo>> GetAllManagerTaxNumbersAsync(bool sorted)
        {
            IQueryable<Manager> querable = Context.Set<Manager>();

            if (sorted)
            {
                return await querable
                    .OrderBy(m => m.Name)
                    .Select(m => new ManagerTaxNumberInfo(m.TaxNumber, m.Name))
                    .ToListAsync();
            }

            return await querable
                     .Select(m => new ManagerTaxNumberInfo(m.TaxNumber, m.Name))
                     .ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetTotalManagementAreaByManagerAsync()
        {
            return await Context.Set<Manager>()
                .Include(m => m.Parcels)
                .ToDictionaryAsync(
                    m => m.Name,
                    m => m.Parcels.Sum(p => p.Area.Value)
                );
        }
    }
}
