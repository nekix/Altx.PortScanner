using Altx.PortScanner.Nmap.Consts;

namespace Altx.PortScanner.Nmap.Inputs.Targets.Ports;

/// <summary>
/// Диапозон портов (или одиночный порта когда StartPort равен EndPort)
/// для сканирования. Опционально протокол для заданного диапозона.
/// </summary>
public sealed record PortRange
{
    /// <summary>
    /// Gets the start port (include).
    /// </summary>
    /// <value>
    /// The start port.
    /// </value>
    public int StartPort { get; private set; }

    /// <summary>
    /// Gets the end port (include).
    /// </summary>
    /// <value>
    /// The end port.
    /// </value>
    public int EndPort { get; private set; }

    /// <summary>
    /// Gets the protocol for scanning a current range of ports.
    /// </summary>
    /// <value>
    /// The protocol.
    /// </value>
    public PortProtocol Protocol { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PortRange"/> class.
    /// </summary>
    /// <param name="port">The port.</param>
    /// <param name="protocol">The protocol.</param>
    public PortRange(int port, PortProtocol protocol = PortProtocol.None)
    {
        Check.Range(port,
            nameof(port),
            OptionsConsts.PortRangeMinValue,
            OptionsConsts.PortRangeMaxValue);

        StartPort = port;
        EndPort = port;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PortRange"/> class.
    /// </summary>
    /// <param name="startPort">The start port.</param>
    /// <param name="endPort">The end port.</param>
    /// <exception cref="ArgumentException">The start port '{startPort}' must be less than or equal to the end port '{endPort}'. - startPort</exception>
    public PortRange(int startPort, int endPort, PortProtocol protocol = PortProtocol.None)
    {
        Check.Range(startPort,
        nameof(startPort),
        OptionsConsts.PortRangeMinValue,
        OptionsConsts.PortRangeMaxValue);

        Check.Range(endPort,
    nameof(endPort),
    OptionsConsts.PortRangeMinValue,
    OptionsConsts.PortRangeMaxValue);

        if (startPort > endPort)
            throw new ArgumentException($"The start port '{startPort}' must be less than or equal to the end port '{endPort}'.",
                nameof(startPort));

        StartPort = startPort;
        EndPort = endPort;
    }
}
