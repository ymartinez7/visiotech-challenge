﻿using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Domain.Entities;

namespace Visiotech.VineyardManagementService.Domain.Repositories
{
    public interface IGrapeRepository : IBaseRepository<Grape>
    {
        Task<Dictionary<string, int>> GetTotalPlantedAreaByGrapeAsync();
    }
}
