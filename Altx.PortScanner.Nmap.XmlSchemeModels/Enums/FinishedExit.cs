using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Altx.PortScanner.Nmap.XmlSchemeModels.Enums
{
    [GeneratedCode("XmlSchemaClassGenerator", "2.0.0.0")]
    [XmlType("FinishedExit")]
    public enum FinishedExit
    {

        [XmlEnum("error")]
        Error,

        [XmlEnum("success")]
        Success,
    }
}