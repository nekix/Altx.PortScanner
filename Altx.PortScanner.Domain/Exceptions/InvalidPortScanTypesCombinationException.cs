namespace Altx.PortScanner.Exceptions;

[Serializable]
public class InvalidPortScanTypesCombinationException : BusinessException
{
    internal InvalidPortScanTypesCombinationException()
        : base(DomainErrorCodes.InvalidPortScanTypesCombination)
    {

    }
}