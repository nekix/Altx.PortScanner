using Altx.PortScanner.Clock;
using Altx.PortScanner.Guids;

namespace Altx.PortScanner.Services;

public class ScanTaskDomainService
{
    private IClock _clock;
    private IGuidGenerator _guidGenerator;

    public ScanTaskDomainService(IClock clock, IGuidGenerator generator)
    {
        _clock = Check.NotNull(clock, nameof(clock));
        _guidGenerator = Check.NotNull(generator, nameof(generator));
    }

    // TODO: To factory class
    public ScanTask CreateScanTask(
        Host host,
        PortRange portRange,
        ScanOptions options)
    {
        var guid = _guidGenerator.Create();
        var creationTime = _clock.Now;

        return new ScanTask(guid, creationTime, host, portRange, options);
    }

    public ScanTask StartTask(ScanTask scanTask)
    {
        var startTime = _clock.Now;

        return scanTask.StartTask(startTime);
    }

    public ScanTask CompleteTask(ScanTask scanTask, ScanResult result)
    {
        var completionTime = _clock.Now;

        return scanTask.CompleteTask(completionTime, result);
    }

    public ScanTask CompleteTaskWithError(ScanTask scanTask)
    {
        var completionTime = _clock.Now;

        return scanTask.CompleteTaskWithError(completionTime);
    }
}
