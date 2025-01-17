﻿using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Enums
{
    [GeneratedCode("XmlSchemaClassGenerator", "2.0.0.0")]
    [XmlType("ScaninfoType")]
    public enum ScanInfoType
    {

        [XmlEnum("syn")]
        Syn,

        [XmlEnum("ack")]
        Ack,

        [XmlEnum("bounce")]
        Bounce,

        [XmlEnum("connect")]
        Connect,

        [XmlEnum("null")]
        Null,

        [XmlEnum("xmas")]
        Xmas,

        [XmlEnum("window")]
        Window,

        [XmlEnum("maimon")]
        Maimon,

        [XmlEnum("fin")]
        Fin,

        [XmlEnum("udp")]
        Udp,

        [XmlEnum("sctpinit")]
        Sctpinit,

        [XmlEnum("sctpcookieecho")]
        Sctpcookieecho,

        [XmlEnum("ipproto")]
        Ipproto,
    }
}