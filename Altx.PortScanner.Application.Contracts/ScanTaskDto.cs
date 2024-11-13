using Altx.PortScanner.Entity;

namespace Altx.PortScanner;

public class ScanTaskDto : IEntityDto<Guid>
{
    public Guid Id { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? CompletionTime { get; set; }

    public string HostName { get; set; } = null!;

    public int? OpenPortsCount { get; set; }

    public int ScanStatus { get; set; }
}