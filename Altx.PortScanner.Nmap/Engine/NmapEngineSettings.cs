namespace Altx.PortScanner.Nmap.Engine;

public class NmapEngineSettings
{
    public string ExecutableNmapPath { get; private set; }

    public NmapEngineSettings(string executableNmapPath)
    {
        Check.NotNullOrWhiteSpace(executableNmapPath, nameof(executableNmapPath));

        if (!File.Exists(executableNmapPath))
            throw new ArgumentException($"Executable file from path '{executableNmapPath}' not exist!", nameof(executableNmapPath));
        
        ExecutableNmapPath = executableNmapPath;
    }
}