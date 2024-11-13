using Microsoft.Extensions.Logging;

namespace Altx.PortScanner.Exceptions;

public interface IHasLogLevel
{
    LogLevel LogLevel { get; }
}
