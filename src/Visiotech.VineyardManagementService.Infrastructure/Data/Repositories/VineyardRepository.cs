using Microsoft.EntityFrameworkCore;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Repositories
{
    public sealed class VineyardRepository(AppDbContext context) : BaseRepository<Vineyard>(context), IVineyardRepository
    {
        public async Task<Dictionary<string, List<string>>> GetVineyardsWithManagersAsync()
        {
            return await Context.Set<Parcel>()
                .Include(p => p.Vineyard)
                .Include(p => p.Manager)
                .Where(p => p.Vineyard != null && p.Manager != null)
                .GroupBy(p => p.Vineyard.Name)
                .Select(g => new
                {
                    VineyardName = g.Key,
                    Managers = g.Select(p => p.Manager.Name)
                                .Distinct()
                                .OrderBy(name => name)
                                .ToList()
                })
                .ToDictionaryAsync(g => g.VineyardName, g => g.Managers);
        }
    }
}
