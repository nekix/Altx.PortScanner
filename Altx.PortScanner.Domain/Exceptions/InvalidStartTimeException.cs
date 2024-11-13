namespace Altx.PortScanner.Exceptions;

[Serializable]
public class InvalidStartTimeException : BusinessException
{
    internal InvalidStartTimeException(DateTime startTime, DateTime creationTime)
        : base(DomainErrorCodes.InvalidStartTime)
    {
    }
}