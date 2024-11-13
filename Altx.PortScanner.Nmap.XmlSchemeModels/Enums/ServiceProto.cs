using System.Xml.Serialization;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Enums
{
    [XmlType("ServiceProto")]
    public enum ServiceProto
    {
        [XmlEnum("rpc")]
        Rpc,
    }
}
