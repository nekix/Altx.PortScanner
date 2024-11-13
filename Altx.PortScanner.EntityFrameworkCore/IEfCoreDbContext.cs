using Altx.PortScanner.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Altx.PortScanner;

public interface IEfCoreDbContext<TEntity, TKey> : IDisposable
    where TEntity : class, IEntity<TKey>
{
    DbSet<TEntity> Set();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    EntityEntry<TEntity> Update(TEntity entity);
}
