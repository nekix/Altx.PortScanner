namespace Altx.PortScanner.Nmap.Input;

public interface IArgument
{
    /// <summary>
    /// Returns the argument string for nmap params.
    /// </summary>
    /// <returns></returns>
    public string GetArgument();
}
