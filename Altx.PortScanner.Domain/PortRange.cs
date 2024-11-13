using Altx.PortScanner.Exceptions;

namespace Altx.PortScanner;

public class PortRange
{
    /// <summary>
    /// Gets the start port (include).
    /// </summary>
    /// <value>
    /// The start port.
    /// </value>
    public int StartPort { get; }

    /// <summary>
    /// Gets the end port (include).
    /// </summary>
    /// <value>
    /// The end port.
    /// </value>
    public int EndPort { get; }

    #region ORM
    #pragma warning disable CS8618
    /// <summary>
    /// Only for ORM and serialization. Do not use!
    /// </summary>
    [Obsolete("Only for ORM and serialization. Do not use!")]

    private PortRange()

    {
        // Only for ORM and serialization. Do not use!
    }
    #pragma warning restore CS8618
    #endregion

    public PortRange(int startPort, int endPort)
    {
        Check.Range(startPort,
            nameof(startPort),
            DomainConsts.PortMinNumber,
            DomainConsts.PortMaxNumber);

        Check.Range(startPort,
            nameof(endPort),
            DomainConsts.PortMinNumber,
            DomainConsts.PortMaxNumber);

        if (startPort > endPort)
            throw new InvalidPortRangeBoundariesException(startPort, endPort);

        StartPort = startPort;
        EndPort = endPort;
    }
}
