using Microsoft.Extensions.Caching.Distributed;

namespace Visiotech.VineyardManagementService.Infrastructure.Caching
{
    public static class RedisCacheOptions
    {
        public static DistributedCacheEntryOptions DefaultCacheOptions => new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public static DistributedCacheEntryOptions Create(TimeSpan? expiration) =>
            expiration is not null ?
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration.Value
            }
            : DefaultCacheOptions;
    }
}
