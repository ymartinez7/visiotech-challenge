using Microsoft.EntityFrameworkCore;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Domain.ValueObjects;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Repositories
{
    public sealed class ManagerRepository(AppDbContext context) : BaseRepository<Manager>(context), IManagerRepository
    {
        public async Task<IReadOnlyCollection<int>> GetAllManagerIdsAsync()
        {
            return await Context.Set<Manager>()
                .Select(m => m.Id)
                .OrderBy(id => id)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<TaxNumber>> GetAllManagerTaxNumbersAsync(bool sorted)
        {
            IQueryable<Manager> querable = Context.Set<Manager>();

            if(sorted)
            {
                return await querable
                    .OrderBy(m => m.Name)
                    .Select(m => m.TaxNumber)
                    .ToListAsync();
            }

            return await querable
                 .Select(m => m.TaxNumber)
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
