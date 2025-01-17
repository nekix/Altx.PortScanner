﻿using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Enums
{
    [GeneratedCode("XmlSchemaClassGenerator", "2.0.0.0")]
    [XmlType("taskend", AnonymousType = true)]
    [XmlRoot("taskend")]
    public class Taskend
    {

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der diese Entität eindeutig identifiziert, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value uniquely identifying this entity.</para>
        /// </summary>

        [Key()]
        public long Id { get; set; }

        [XmlAttribute("task", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Task { get; set; }

        [XmlAttribute("time", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Time { get; set; }

        [XmlAttribute("extrainfo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Extrainfo { get; set; }
    }
}