using System.Xml.Serialization;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Enums
{
    [XmlType("HostnameType")]
    public enum HostNameType
    {
        [XmlEnum("user")]
        User,

        [XmlEnum("PTR")]
        PTR,
    }
}