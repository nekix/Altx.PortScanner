using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altx.PortScanner.EntityFrameworkCore;

public class ScanResultConfiguration : IEntityTypeConfiguration<ScanResult>
{
    public void Configure(EntityTypeBuilder<ScanResult> builder)
    {
        builder.HasKey(x => x.ScanTaskId);

        builder.OwnsMany(x => x.Ports, b => b.ToJson());
    }
}
