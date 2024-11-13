using System.Numerics;

namespace Altx.PortScanner.Nmap.Input.ScanTypes;

public sealed class PortScanTypesSettings : IArguments
{
    #region Static mapper
    // TODO: Maybe move to inner static class or separate.

    private static readonly IReadOnlyList<KeyValuePair<PortScanTypes, string>> PortScanTypesMap;

    static PortScanTypesSettings()
    {
        PortScanTypesMap = new List<KeyValuePair<PortScanTypes, string>>
        {
            new(PortScanTypes.TcpSyn, "-sS"),
            new(PortScanTypes.TcpConnect, "-sT" ),
            new(PortScanTypes.Udp, "-sU" ),
            new(PortScanTypes.TcpNull, "-sN" ),
            new(PortScanTypes.TcpFin, "-sF" ),
            new(PortScanTypes.TcpXmas, "-sX" )
        };
    }

    #endregion

    public PortScanTypes ScanTypes { get; private set; }

    public PortScanTypesSettings(PortScanTypes scanTypes)
    {
        CheckIsValidFlags(scanTypes);

        int flagsCount = CountFlags(scanTypes);

        if (flagsCount == 0)
            throw new ArgumentException("Scan types is empty! Scan types must be specified.", nameof(scanTypes));

        // The maximum number of scan types is 2.
        if (flagsCount > 2)
            throw new ArgumentException("More than two types of scans! There cannot be more than two scanning types.", nameof(scanTypes));

        // Only Udp with Tcp combinations allowed.
        if (flagsCount == 2 && !ContainScanType(scanTypes, PortScanTypes.Udp))
            throw new ArgumentException($"'{scanTypes}' are invalid scan types combination!", nameof(scanTypes));

        ScanTypes = scanTypes;
    }

    private static bool ContainScanType(PortScanTypes scanTypes, PortScanTypes targetScansType)
        => (scanTypes & targetScansType) != 0;

    private static void CheckIsValidFlags(PortScanTypes scanTypes)
    {
        var isInvalidFlag = (scanTypes & ~PortScanTypesHelper.AllScanTypesMask) != 0;

        if (isInvalidFlag)
            throw new ArgumentException("Invalid scan types value!", nameof(scanTypes));
    }

    private int CountFlags(PortScanTypes scanTypes)
        => BitOperations.PopCount((uint)scanTypes);

    public List<string> GetArguments()
    {
        return PortScanTypesMap
            .Where(m => ScanTypes.HasFlag(m.Key))
            .Select(m => m.Value)
            .ToList();
    }
}