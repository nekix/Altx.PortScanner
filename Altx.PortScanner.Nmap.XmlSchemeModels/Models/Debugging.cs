using System.Xml.Serialization;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Models
{
    [XmlType("debugging", AnonymousType = true)]
    [XmlRoot("debugging")]
    public class Debugging
    {
        [XmlAttribute("level")]
        public int Level { get; set; }
    }
}