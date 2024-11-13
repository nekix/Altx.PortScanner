using Altx.PortScanner.Exceptions;

namespace Altx.PortScanner;

public class ScanOptions
{
    private List<PortScanType> _portScanTypes;

    // IReadOnlyCollections EfCore mapping implemented in .NET9)
    // https://github.com/dotnet/efcore/issues/25364
    public List<PortScanType> PortScanTypes => _portScanTypes;

    #region ORM
    #pragma warning disable CS8618
    /// <summary>
    /// Only for ORM and serialization. Do not use!
    /// </summary>
    [Obsolete("Only for ORM and serialization. Do not use!")]

    private ScanOptions()

    {
        // Only for ORM and serialization. Do not use!
    }
    #pragma warning restore CS8618
    #endregion

    public ScanOptions(IEnumerable<PortScanType> portScanTypes)
    {
        var scanTypes = new List<PortScanType>(portScanTypes);

        if (scanTypes.Count > 2)
            throw new PortScanTypesInvalidCountException();

        if (scanTypes.Count > 1)
            CheckDuplicates(scanTypes);

        if (scanTypes.Count == 2 && !scanTypes.Contains(PortScanType.Udp))
            throw new InvalidPortScanTypesCombinationException();

        _portScanTypes = new List<PortScanType>(scanTypes);
    }

    private void CheckDuplicates(List<PortScanType> portScanTypes)
    {
        var duplicates = portScanTypes.GroupBy(t => t)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (duplicates.Count != 0)
            throw new DuplicatePortScanTypesException(duplicates);
    }
}