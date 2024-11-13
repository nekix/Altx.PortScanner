namespace Altx.PortScanner;

public enum PortState
{
    /// <summary>
    /// Состояние порта не задано.
    /// </summary>
    None,

    /// <summary>
    /// Порт открыт и принимает запросы на TCP или UDP.
    /// </summary>
    Open,

    /// <summary>
    /// Порт доступен, но не используется каким-либо приложением.
    /// </summary>
    Closed,

    /// <summary>
    /// Порт фильтруется, неизвестно, открыт он или закрыт.
    /// </summary>
    Filtered,

    /// <summary>
    /// Порт доступен, но неизвестно, открыт он или закрыт.
    /// </summary>
    Unfiltered,

    /// <summary>
    /// Порт либо открыт, либо фильтруется, но точное состояние неизвестно.
    /// </summary>
    OpenFiltered,

    /// <summary>
    /// Порт либо закрыт, либо фильтруется, но точное состояние неизвестно.
    /// </summary>
    ClosedFiltered
}