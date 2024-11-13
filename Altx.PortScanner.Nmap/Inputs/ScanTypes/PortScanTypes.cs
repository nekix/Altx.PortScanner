namespace Altx.PortScanner.Nmap.Input.ScanTypes;

/// <summary>
/// Перечисление режимов сканирования Nmap с возможностью комбинирования.
/// Ссылка на документацию: https://nmap.org/book/man-port-scanning-techniques.html
/// </summary>
[Flags]
public enum PortScanTypes
{
    /// <summary>
    /// TCP SYN сканирование.
    /// Параметр для Nmap: -sS
    /// Подробнее: https://nmap.org/book/man-port-scanning-techniques.html#synscan
    /// </summary>
    TcpSyn = 1 << 0,

    /// <summary>
    /// TCP Connect сканирование.
    /// Параметр для Nmap: -sT
    /// Подробнее: https://nmap.org/book/man-port-scanning-techniques.html#tcpconnectscan
    /// </summary>
    TcpConnect = 1 << 1,

    /// <summary>
    /// UDP сканирование.
    /// Параметр для Nmap: -sU
    /// Подробнее: https://nmap.org/book/man-port-scanning-techniques.html#udpscan
    /// </summary>
    Udp = 1 << 2,

    /// <summary>
    /// TCP Null сканирование.
    /// Параметр для Nmap: -sN
    /// Подробнее: https://nmap.org/book/man-port-scanning-techniques.html#nullscan
    /// </summary>
    TcpNull = 1 << 3, // -sN

    /// <summary>
    /// FIN сканирование.
    /// Параметр для Nmap: -sF
    /// Подробнее: https://nmap.org/book/man-port-scanning-techniques.html#finscan
    /// </summary>
    TcpFin = 1 << 4, // -sF

    /// <summary>
    /// Xmas Tree сканирование.
    /// Параметр для Nmap: -sX
    /// Подробнее: https://nmap.org/book/man-port-scanning-techniques.html#xmasscan
    /// </summary>
    TcpXmas = 1 << 5, // -sX

    // TODO: Others
}

internal static class PortScanTypesHelper
{
    internal static PortScanTypes AllScanTypesMask
        => PortScanTypes.TcpSyn |
           PortScanTypes.TcpConnect |
           PortScanTypes.Udp |
           PortScanTypes.TcpNull |
           PortScanTypes.TcpFin |
           PortScanTypes.TcpXmas;
}