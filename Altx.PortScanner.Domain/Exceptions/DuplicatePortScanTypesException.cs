namespace Altx.PortScanner.Exceptions;

public class DuplicatePortScanTypesException : BusinessException
{
    internal DuplicatePortScanTypesException(IEnumerable<PortScanType> scanTypes)
        : base(DomainErrorCodes.DuplicatePortScanTypes)
    {
        WithData("PortScanTypes", scanTypes.ToList());
    }
}
