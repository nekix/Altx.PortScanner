namespace Altx.PortScanner.Exceptions;

[Serializable]
public class ScanTaskAlreadyStartedException : BusinessException
{
    internal ScanTaskAlreadyStartedException(ScanStatus currentStatus)
        : base(DomainErrorCodes.ScanTaskAlreadyStarted)
    {
        WithData("Status", currentStatus);
    }
}