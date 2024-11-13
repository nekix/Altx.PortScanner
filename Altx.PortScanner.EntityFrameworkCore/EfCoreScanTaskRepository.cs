using Altx.PortScanner.EntityFrameworkCore;
using Altx.PortScanner.Repositories;
using Company;

namespace Altx.PortScanner;

public class EfCoreScanTaskRepository :
    EfCoreRepository<ScanTaskDbContext, ScanTask, Guid>,
    IScanTaskRepository
{
    public EfCoreScanTaskRepository(ScanTaskDbContext context) : base(context)
    {
    }
}
