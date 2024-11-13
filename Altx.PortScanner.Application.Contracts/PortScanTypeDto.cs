namespace Altx.PortScanner
{
    /// <summary>
    /// Enumeration of port scan modes.
    /// </summary>
    public enum PortScanTypeDto
    {
        /// <summary>
        /// TCP SYN сканирование.
        /// </summary>
        TcpSyn,

        /// <summary>
        /// TCP Connect сканирование.
        /// </summary>
        TcpConnect,

        /// <summary>
        /// UDP сканирование.
        /// </summary>
        Udp,
    }
}