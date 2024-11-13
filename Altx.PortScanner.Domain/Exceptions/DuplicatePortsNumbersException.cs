namespace Altx.PortScanner.Exceptions;

[Serializable]
public class DuplicatePortsNumbersException : BusinessException
{
    internal DuplicatePortsNumbersException()
        : base(DomainErrorCodes.DuplicatePortsNumbers)
    {
    }
}