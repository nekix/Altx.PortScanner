namespace Altx.PortScanner.Guids;

/// <summary>
/// Used to generate Ids.
/// </summary>
public interface IGuidGenerator
{
    /// <summary>
    /// Creates a new System.Guid.
    /// </summary>
    /// <returns></returns>
    Guid Create();
}
