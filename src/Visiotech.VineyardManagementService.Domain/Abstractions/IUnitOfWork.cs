namespace Visiotech.VineyardManagementService.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
