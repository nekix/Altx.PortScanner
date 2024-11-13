namespace Altx.PortScanner.Exceptions;

[Serializable]
public class PortScanTypesInvalidCountException : BusinessException
{
    internal PortScanTypesInvalidCountException()
        : base(DomainErrorCodes.PortScanTypesInvalidCount)
    {

    }
}