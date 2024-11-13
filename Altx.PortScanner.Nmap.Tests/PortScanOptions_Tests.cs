using Altx.PortScanner.Nmap.Input.ScanTypes;
using Shouldly;

namespace Altx.PortScanner.Nmap.Tests;

public class PortScanOptions_Tests
{
    [Fact]
    public void Should_Create()
    {
        var validScanTypes = PortScanTypes.TcpSyn | PortScanTypes.Udp;

        var portScanOptions = new PortScanTypesSettings(validScanTypes);

        Assert.Equal(validScanTypes, portScanOptions.ScanTypes);
    }

    [Fact]
    public void Should_Throw_When_ScanTypes_Is_Empty()
    {
        var invalidScanTypes = (PortScanTypes)0;

        var exception = Assert.Throws<ArgumentException>(() => new PortScanTypesSettings(invalidScanTypes));
        exception.ShouldNotBeNull();
        exception.Message.ShouldNotBeNullOrWhiteSpace();
        exception.ParamName.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Should_Throw_When_More_Than_Two_ScanTypes()
    {
        var invalidScanTypes = PortScanTypes.TcpSyn | PortScanTypes.Udp | PortScanTypes.TcpConnect;

        var exception = Assert.Throws<ArgumentException>(() => new PortScanTypesSettings(invalidScanTypes));
        exception.ShouldNotBeNull();
        exception.Message.ShouldNotBeNullOrWhiteSpace();
        exception.ParamName.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Should_Throw_When_Invalid_ScanTypes_Combination()
    {
        var invalidScanTypes = PortScanTypes.TcpSyn | PortScanTypes.TcpNull;

        var exception = Assert.Throws<ArgumentException>(() => new PortScanTypesSettings(invalidScanTypes));
        exception.ShouldNotBeNull();
        exception.Message.ShouldNotBeNullOrWhiteSpace();
        exception.ParamName.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Should_Throw_When_Invalid_ScanType_Flags()
    {
        var invalidScanTypes = (PortScanTypes)(1 << 10);

        var exception = Assert.Throws<ArgumentException>(() => new PortScanTypesSettings(invalidScanTypes));
        exception.ShouldNotBeNull();
        exception.Message.ShouldNotBeNullOrWhiteSpace();
        exception.ParamName.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Should_Throw_When_Single_ScanType()
    {
        var validScanTypes = PortScanTypes.TcpSyn;

        var portScanOptions = new PortScanTypesSettings(validScanTypes);

        Assert.Equal(validScanTypes, portScanOptions.ScanTypes);
    }
}