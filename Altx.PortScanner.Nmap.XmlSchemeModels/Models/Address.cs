using System.ComponentModel;
using System.Xml.Serialization;
using Altx.PortScanner.Nmap.XmlSchemeModels.Enums;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Models
{
    [XmlType("address", AnonymousType = true)]
    [XmlRoot("address")]
    public class Address
    {
        [XmlAttribute("addr")]
        public string IP { get; set; }

        [XmlAttribute("addrtype"), DefaultValue(AddressType.IPv4)]
        public AddressType Type { get; set; }

        [XmlAttribute("vendor")]
        public string Vendor { get; set; }
    }
}