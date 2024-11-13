using Altx.PortScanner.Nmap.Input;

namespace Altx.PortScanner.Nmap.Inputs.Targets.Hosts;

public sealed class HostTarget : IArgument
{
    public string HostName { get; private set; }

    public HostTarget(string hostName)
    {
        Check.NotNullOrWhiteSpace(hostName, nameof(hostName));

        var hostNameType = Uri.CheckHostName(hostName);

        if (hostNameType is UriHostNameType.Basic or UriHostNameType.Unknown)
            throw new ArgumentException($"Hostname '{hostName}' has invalid format!", hostName);

        HostName = hostName;
    }

    public string GetArgument()
        => HostName;
}