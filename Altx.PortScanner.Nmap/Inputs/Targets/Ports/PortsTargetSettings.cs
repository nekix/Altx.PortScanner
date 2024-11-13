using System.Text;
using Altx.PortScanner.Nmap.Input;

namespace Altx.PortScanner.Nmap.Inputs.Targets.Ports;

public class PortsTargetSettings : IArgument
{
    #region Static mapper
    // TODO: Maybe move to inner static class or separate.

    private static readonly IReadOnlyList<KeyValuePair<PortProtocol, string>> PortProtocolsMap;

    static PortsTargetSettings()
    {
        PortProtocolsMap = new List<KeyValuePair<PortProtocol, string>>
        {
            new(PortProtocol.None, string.Empty),
            new(PortProtocol.Tcp, "U"),
            new(PortProtocol.Udp, "T"),
        };
    }
    #endregion

    private readonly List<PortRange> _ports;
    public IReadOnlyList<PortRange> Ports => _ports;

    public PortsTargetSettings(PortRange portRange)
    {
        Check.NotNull(portRange, nameof(portRange));

        _ports = new List<PortRange>();

        // TODO: Validate duplicates and intersections.

        _ports.Add(portRange);
    }

    public PortsTargetSettings(IEnumerable<PortRange> ports)
    {
        Check.NotNull(ports, nameof(ports));

        _ports = new List<PortRange>();

        // TODO: Validate duplicates and intersections.

        _ports.AddRange(ports);
    }

    public string GetArgument()
    {
        // TODO: Реализация на скорую руку и неэффективная,
        // необходимо оптимизировать и рефакторить.

        var argBuilder = new StringBuilder();

        argBuilder.Append("-p ");

        var withoutProtocolPortArgs = _ports.Where(p => p.Protocol == PortProtocol.None)
            .Select(MapPortRangeToArgument);

        argBuilder.AppendJoin(',', withoutProtocolPortArgs);

        var withProtocolPortsGroups = _ports.Where(p => p.Protocol != PortProtocol.None)
            .GroupBy(p => p.Protocol);

        foreach (var group in withProtocolPortsGroups)
        {
            string? portProtocol = PortProtocolsMap.FirstOrDefault(m => m.Key == group.Key).Value;
            if (portProtocol == null)
                throw new ArgumentException("Not existed port protocol format!", nameof(portProtocol));

            argBuilder.Append(',');
            argBuilder.Append(portProtocol);
            argBuilder.Append(':');

            argBuilder.AppendJoin(',', group.Select(MapPortRangeToArgument));
        }

        return argBuilder.ToString();
    }

    private static string MapPortRangeToArgument(PortRange portRange)
    {
        if (portRange.StartPort == portRange.EndPort)
        {
            return portRange.StartPort.ToString();
        }
        else
        {
            return $"{portRange.StartPort}-{portRange.EndPort}";
        }
    }
}
