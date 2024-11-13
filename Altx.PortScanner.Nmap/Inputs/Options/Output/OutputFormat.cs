namespace Altx.PortScanner.Nmap.Input.Options.Output;

/// <summary>
/// Перечисление форматов вывода Nmap.
/// Ссылка на документацию: https://nmap.org/book/man-output.html
/// </summary>
public enum OutputFormat
{
    ///// <summary>
    ///// Текстовый формат (по умолчанию).
    ///// Параметр для Nmap: -oN.
    ///// Подробнее: https://nmap.org/book/man-output.html
    ///// </summary>
    //Normal,

    /// <summary>
    /// Формат XML.
    /// Параметр для Nmap: -oX.
    /// Подробнее: https://nmap.org/book/man-output.html
    /// </summary>
    Xml

    // TODO: Others
}
