namespace Altx.PortScanner;

public class ScanPortInfo
{
    public int PortNumber { get; private set; }

    public PortState State { get; private set; }

    #region ORM
    #pragma warning disable CS8618
    /// <summary>
    /// Only for ORM and serialization. Do not use!
    /// </summary>
    [Obsolete("Only for ORM and serialization. Do not use!")]

    private ScanPortInfo()

    {
        // Only for ORM and serialization. Do not use!
    }
    #pragma warning restore CS8618
    #endregion

    internal ScanPortInfo(int portNumber, PortState state)
    {
        PortNumber = Check.Range(portNumber,
            nameof(portNumber),
            DomainConsts.PortMinNumber,
            DomainConsts.PortMaxNumber);

        State = state;
    }
}
