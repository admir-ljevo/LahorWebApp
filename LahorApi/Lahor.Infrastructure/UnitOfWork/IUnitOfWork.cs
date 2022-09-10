
using Microsoft.EntityFrameworkCore.Storage;

namespace Lahor.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> ExecuteAsync(Func<Task> action);
        IDbContextTransaction BeginTransaction();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
