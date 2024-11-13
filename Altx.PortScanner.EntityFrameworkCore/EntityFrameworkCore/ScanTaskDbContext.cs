using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Altx.PortScanner.EntityFrameworkCore;

public class ScanTaskDbContext : DbContext, IEfCoreDbContext<ScanTask, Guid>
{
    public DbSet<ScanTask> ScanTasks { get; set; }

    public ScanTaskDbContext(DbContextOptions<ScanTaskDbContext> options)
        : base(options)
    {

    }

    public DbSet<ScanTask> Set()
        => ScanTasks;

    public EntityEntry<ScanTask> Update(ScanTask entity)
        => base.Update(entity);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ScanTaskConfiguration());
        modelBuilder.ApplyConfiguration(new ScanResultConfiguration());
    }
}