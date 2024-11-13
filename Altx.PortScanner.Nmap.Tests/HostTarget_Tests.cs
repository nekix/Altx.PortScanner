using Altx.PortScanner.Nmap.Inputs.Targets.Hosts;
using Shouldly;

namespace Altx.PortScanner.Nmap.Tests;

public class HostTarget_Tests
{
    [Theory]
    [InlineData("google.com")]
    [InlineData("sub.example.com")]
    [InlineData("my-domain.org")]
    [InlineData("example123.net")]
    [InlineData("192.168.1.1")]
    [InlineData("10.0.0.1")]
    [InlineData("255.255.255.255")]
    [InlineData("2001:0db8:85a3:0000:0000:8a2e:0370:7334")]
    [InlineData("fe80::1ff:fe23:4567:890a")]
    [InlineData("::1")]
    public void Should_Create(string hostName)
    {
        var hostTarget = new HostTarget(hostName);

        hostTarget.HostName.ShouldBe(hostName);
    }

    [Theory]
    [InlineData("1234::5678::9abc")]
    [InlineData("192.168.1.1/24")]
    public void Should_Throw_When_Not_Valid_HostName(string hostName)
    {
        var exception = Should.Throw<ArgumentException>(() => new HostTarget(hostName));

        exception.ShouldNotBeNull();
    }
}