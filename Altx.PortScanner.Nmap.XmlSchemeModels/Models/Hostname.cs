using System.Xml.Serialization;
using Altx.PortScanner.Nmap.XmlSchemeModels.Enums;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Models
{
    [XmlType("hostname", AnonymousType = true)]
    [XmlRoot("hostname")]
    public class Hostname
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public HostNameType Type { get; set; }
    }
}