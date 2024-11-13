namespace Altx.PortScanner.Nmap.Inputs.Targets.Ports;

/// <summary>
///   <para>
/// Перечисление протоколов, которые можно задать диапозону(ам) портов.</para>
///   <para>
///     <a href="https://nmap.org/book/man-port-specification.html">Смотри подробнее в документации nmap</a>
///   </para>
/// </summary>
public enum PortProtocol
{
    /// <summary>
    /// Соответствует отсутсвию заданного протокола.
    /// Автоматически запускаются указанный(е) в опция сканирования протоколы.
    /// </summary>
    None,

    /// <summary>
    /// TCP протокол.
    /// Соответсвует шаблону 'T:'
    /// Подробнее: https://nmap.org/book/man-port-specification.html
    /// </summary>
    Tcp,

    /// <summary>
    /// UDP протокол.
    /// Соответсвует шаблону 'U:'
    /// Подробнее: https://nmap.org/book/man-port-specification.html
    /// </summary>
    Udp

    // TODO: Others
}
