using Microsoft.Extensions.Logging;

namespace Altx.PortScanner.Exceptions;

/// <summary>
/// The BusinessException class represents an exception specifically for business logic errors
/// that are predictable and manageable.
/// </summary>
[Serializable]
public class BusinessException : Exception,
    IBusinessException,
    IHasErrorCode,
    IHasErrorDetails,
    IHasLogLevel
{
    /// <summary>
    /// Gets the error code.
    /// </summary>
    /// <value>
    /// The error code.
    /// </value>
    public string? Code { get; private set; }

    /// <summary>
    /// Gets the error details.
    /// </summary>
    /// <value>
    /// The error details.
    /// </value>
    public string? Details { get; private set; }

    /// <summary>
    /// Gets the log level.
    /// </summary>
    /// <value>
    /// The log level.
    /// </value>
    public LogLevel LogLevel { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessException"/> class.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <param name="message">The message.</param>
    /// <param name="details">The details.</param>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="logLevel">The log level.</param>
    public BusinessException(
        string? code = null,
        string? message = null,
        string? details = null,
        Exception? innerException = null,
        LogLevel logLevel = LogLevel.Warning)
        : base(message, innerException)
    {
        Code = code;
        Details = details;
        LogLevel = logLevel;
    }

    /// <summary>
    /// Add data to exception by key.
    /// </summary>
    /// <param name="name">The data record key.</param>
    /// <param name="value">The data value.</param>
    /// <returns></returns>
    public BusinessException WithData(string name, object value)
    {
        Data[name] = value;
        return this;
    }
}
