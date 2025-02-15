using Visiotech.VineyardManagementService.Domain.Entities;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Repositories
{
    public class ManagerRepository(AppDbContext ccntext) : BaseRepository<Manager>(ccntext), IManagerRepository
    {
    }
}
