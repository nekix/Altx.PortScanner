namespace Altx.PortScanner.Nmap.Input;

public interface IArguments
{
    /// <summary>
    /// Returns the argument collection for nmap params.
    /// </summary>
    /// <returns></returns>
    public List<string> GetArguments();
}
