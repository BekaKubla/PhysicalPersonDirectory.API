namespace PhysiscalPersonDirectory.Domain.SeedWork.Base
{
    public interface IGenericUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
