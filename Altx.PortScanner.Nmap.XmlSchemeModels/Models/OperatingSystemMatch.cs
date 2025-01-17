﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Models
{
    [XmlType("osmatch", AnonymousType = true)]
    [XmlRoot("osmatch")]
    public class OperatingSystemMatch
    {
        [XmlElement("osclass")]
        public List<OperatingSystemClass> Class { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("accuracy")]
        public string Accuracy { get; set; }

        [XmlAttribute("line")]
        public string Line { get; set; }
    }
}