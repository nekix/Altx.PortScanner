using Altx.PortScanner.Nmap.Input.Options.Output;
using Altx.PortScanner.Nmap.Input.ScanTypes;
using Altx.PortScanner.Nmap.Inputs.Targets.Hosts;
using Altx.PortScanner.Nmap.Inputs.Targets.Ports;
using Altx.PortScanner.Nmap.XmlSchemeModels;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;

namespace Altx.PortScanner.Nmap.Engine;

public sealed class NmapEngine
{
    private readonly NmapEngineSettings _settings;
    private readonly XmlSerializer _nmapResultSerializer;

    public NmapEngine(NmapEngineSettings settings)
    {
        _settings = Check.NotNull(settings, nameof(settings));

        _nmapResultSerializer = new XmlSerializer(typeof(NMapResult));
    }

    public async Task<NMapResult> ScanPorts(
        HostTarget hostTarget,
        PortScanTypesSettings portScanTypesSettings,
        OutputSettings outputSettings,
        PortsTargetSettings portsSettings)
    {
        // TODO: передачу в параметраъ всех настроек
        // следует заменить на класс ScanPortSettings,
        // который будет валидировать сочетания аргументов.
        // Туда же перенести ConvertSettingToArguments.

        string arguments = ConvertSettingToArguments(hostTarget, portScanTypesSettings, outputSettings, portsSettings);

        using Process process = CreateNmapScanPortsProcess(arguments);

        process.Start();

        using var outputStream = process.StandardOutput;
        // TODO: Handle errors also.

        await process.WaitForExitAsync();

        return ParseOutput(outputStream);
    }

    private static string ConvertSettingToArguments(HostTarget hostTarget, PortScanTypesSettings portScanTypesSettings, OutputSettings outputSettings, PortsTargetSettings portsSettings)
    {
        var scanArguments = new List<string>();

        scanArguments.AddRange(portScanTypesSettings.GetArguments());
        scanArguments.AddRange(outputSettings.GetArguments());
        scanArguments.Add(portsSettings.GetArgument());
        scanArguments.Add(hostTarget.GetArgument());

        var argumentsBuilder = new StringBuilder();

        argumentsBuilder.AppendJoin(' ', scanArguments);

        return argumentsBuilder.ToString();
    }

    private Process CreateNmapScanPortsProcess(string arguments)
    {
        var process = new Process();

        process.StartInfo.FileName = _settings.ExecutableNmapPath;

        process.StartInfo.Arguments = arguments;

        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;

        return process;
    }

    private NMapResult ParseOutput(StreamReader reader)
    {
        return _nmapResultSerializer.Deserialize(reader) as NMapResult
            ?? throw new ArgumentException("Not valid nmap result format!", nameof(reader));
    }
}