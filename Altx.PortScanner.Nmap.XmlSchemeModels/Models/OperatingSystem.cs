﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Models
{
    [XmlType("os", AnonymousType = true)]
    [XmlRoot("os")]
    public class OperatingSystem
    {
        [XmlElement("portused")]
        public List<Port> Ports { get; set; }

        [XmlElement("osmatch")]
        public List<OperatingSystemMatch> Matches { get; set; }

        [XmlElement("osfingerprint")]
        public List<string> Fingerprint { get; set; }
    }
}