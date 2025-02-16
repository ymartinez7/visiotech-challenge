using Microsoft.EntityFrameworkCore;
using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Repositories
{
    public sealed class GrapeRepository(AppDbContext context) : BaseRepository<Grape>(context), IGrapeRepository
    {
        public async Task<Dictionary<string, int>> GetTotalPlantedAreaByGrapeAsync()
        {
            return await Context.Set<Grape>()
                .Include(g => g.Parcels)
                .ToDictionaryAsync(
                    g => g.Name,
                    g => g.Parcels.Sum(p => p.Area.Value)
                );
        }
    }
}
