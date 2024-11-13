namespace Altx.PortScanner.Exceptions;

[Serializable]
public class InvalidPortRangeBoundariesException : BusinessException
{
    internal InvalidPortRangeBoundariesException(int startPort, int endPort)
        : base(DomainErrorCodes.InvalidPortRangeBoundaries)
    {
        WithData("StartPort", startPort);
        WithData("EndPort", endPort);
    }
}