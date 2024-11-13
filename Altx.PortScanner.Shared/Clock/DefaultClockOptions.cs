namespace Altx.PortScanner.Clock;

public class DefaultClockOptions
{
    /// <summary>
    /// Default: <see cref="DateTimeKind.Unspecified"/>
    /// </summary>
    public DateTimeKind Kind { get; set; }

    public DefaultClockOptions()
    {
        Kind = DateTimeKind.Unspecified;
    }
}