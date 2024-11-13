using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altx.PortScanner.EntityFrameworkCore;

internal class ScanTaskConfiguration : IEntityTypeConfiguration<ScanTask>
{
    public void Configure(EntityTypeBuilder<ScanTask> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreationTime)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.OwnsOne(x => x.Host, ConfigureHostOwner)
            .Navigation(x => x.Host);

        builder.OwnsOne(x => x.PortRange, ConfigurePortRangeOwner)
            .Navigation(x => x.PortRange);

        builder.OwnsOne(x => x.Options, ConfigureOptionsOwner)
            .Navigation(x => x.Options);

        builder.HasOne(x => x.Result)
            .WithOne()
            .HasForeignKey<ScanResult>(x => x.ScanTaskId);
    }

    private static void ConfigureScanResultSplitTable(SplitTableBuilder<ScanTask> builder)
    {
        builder.Property(x => x.Id).HasColumnName("ScanTaskId");
        builder.Property(x => x.Result!.Ports).HasColumnName("Ports");
    }

    private static void ConfigureScanResultOwner(
    OwnedNavigationBuilder<ScanTask, ScanResult> builder)
    {
        builder.Property(z => z.Ports)
            .HasColumnName("HostName")
            .IsRequired();

        builder.WithOwner();
    }

    private static void ConfigureHostOwner(
        OwnedNavigationBuilder<ScanTask, Host> builder)
    {
        builder.Property(z => z.HostName)
            .HasColumnName("HostName")
            .IsRequired();

        builder.WithOwner();
    }

    private static void ConfigurePortRangeOwner(
        OwnedNavigationBuilder<ScanTask, PortRange> builder)
    {
        builder.Property(z => z.StartPort)
            .HasColumnName("StartPort")
            .IsRequired();

        builder.Property(z => z.StartPort)
            .HasColumnName("EndPort")
            .IsRequired();

        builder.WithOwner();
    }

    private static void ConfigureOptionsOwner(
        OwnedNavigationBuilder<ScanTask, ScanOptions> builder)
    {
        builder.Property(z => z.PortScanTypes)
            .HasColumnName("ScanTypes")
            .IsRequired();

        builder.WithOwner();
    }
}