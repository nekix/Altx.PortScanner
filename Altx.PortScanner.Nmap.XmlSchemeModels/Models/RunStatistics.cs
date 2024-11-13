using System.Xml.Serialization;
using Altx.PortScanner.Nmap.XmlSchemeModels.Enums;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Models
{
    [XmlType("runstats", AnonymousType = true)]
    [XmlRoot("runstats")]
    public class RunStatistics
    {
        [XmlElement("finished")]
        public Finished Finished { get; set; }

        [XmlElement("hosts")]
        public Hosts Hosts { get; set; }
    }
}