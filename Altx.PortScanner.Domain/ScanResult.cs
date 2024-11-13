using Altx.PortScanner.Exceptions;

namespace Altx.PortScanner;

public class ScanResult
{
    public Guid ScanTaskId { get; private set; }

    private List<ScanPortInfo> _ports;
    public IReadOnlyList<ScanPortInfo> Ports => _ports;

    #region ORM
    #pragma warning disable CS8618
    /// <summary>
    /// Only for ORM and serialization. Do not use!
    /// </summary>
    [Obsolete("Only for ORM and serialization. Do not use!")]

    private ScanResult()

    {
        // Only for ORM and serialization. Do not use!
    }
    #pragma warning restore CS8618
    #endregion

    public ScanResult(Guid scanTaskId, IEnumerable<ScanPortInfo> scanPortInfos)
    {
        ScanTaskId = scanTaskId;

        var ports = new List<ScanPortInfo>(scanPortInfos);

        CheckPortDuplicates(ports);

        _ports = ports;
    }

    private void CheckPortDuplicates(List<ScanPortInfo> scanPortsInfos)
    {
        var duplicates = scanPortsInfos.GroupBy(t => t.PortNumber)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (duplicates.Count != 0)
            throw new DuplicatePortsNumbersException();
    }
}