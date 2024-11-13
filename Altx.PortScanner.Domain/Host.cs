namespace Altx.PortScanner;

public class Host
{
    public string HostName { get; }

    #region ORM
    #pragma warning disable CS8618
    /// <summary>
    /// Only for ORM and serialization. Do not use!
    /// </summary>
    [Obsolete("Only for ORM and serialization. Do not use!")]

    private Host()

    {
        // Only for ORM and serialization. Do not use!
    }
    #pragma warning restore CS8618
    #endregion

    public Host(string hostName)
    {
        Check.NotNullOrWhiteSpace(hostName, nameof(hostName));

        var hostNameType = Uri.CheckHostName(hostName);

        if (hostNameType is UriHostNameType.Basic or UriHostNameType.Unknown)
            throw new ArgumentException($"Hostname '{hostName}' has invalid format!", hostName);

        HostName = hostName;
    }
}