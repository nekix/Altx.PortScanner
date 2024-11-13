using Altx.PortScanner.Nmap.Engine;
using Altx.PortScanner.Nmap.Input.Options.Output;
using Altx.PortScanner.Nmap.Input.ScanTypes;
using Altx.PortScanner.Nmap.Inputs.Targets.Hosts;
using Altx.PortScanner.Nmap.Inputs.Targets.Ports;
using Shouldly;

namespace Altx.PortScanner.Nmap.Tests;

public class NmapEngine_Tests
{
    [Fact]
    public async void Should_Process()
    {
        var settings = new NmapEngineSettings(@"C:\Program Files (x86)\Nmap\nmap.exe");
        var engine = new NmapEngine(settings);

        var target = new HostTarget("manpages.ubuntu.com");
        var scanOptions = new PortScanTypesSettings(PortScanTypes.TcpSyn);
        var nmapOutputOptions = new OutputSettings();
        nmapOutputOptions.AddTarget(OutputTarget.CreateFromStdout(OutputFormat.Xml));

        var port = new PortRange(10, 200, PortProtocol.Tcp);
        var portSettings = new PortsTargetSettings(port);

        var result = await engine.ScanPorts(target, scanOptions, nmapOutputOptions, portSettings);

        result.Hosts.Select(h => h.Ports.Select(p => p.Port)).Count().ShouldNotBe(0);
    }
}