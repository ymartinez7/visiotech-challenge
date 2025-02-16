using Microsoft.EntityFrameworkCore;
using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Repositories
{
    public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : Entity
    {
        protected AppDbContext Context { get; init; } = context;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            ArgumentException.ThrowIfNullOrEmpty(nameof(entity));
            Delete(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
