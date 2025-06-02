using System.Xml.Linq;

namespace XmlFiles.Write;

internal class WriteXmlWithLinq
{
    public WriteXmlWithLinq(string nombreArchivo)
    {
        XElement? empresa = new(
            "empresa",
            new XElement(
                "empleado",
                new XAttribute("id", "1"),
                new XElement("nombre", "empleado 1"),
                new XElement("status", "activo")
            ),
            new XElement(
                "empleado",
                new XAttribute("id", "2"),
                new XElement("nombre", "empleado 2"),
                new XElement("status", "activo")
            ),
            new XElement(
                "empleado",
                new XAttribute("id", "3"),
                new XElement("nombre", "empleado 3"),
                new XElement("status", "activo")
            )
        );

        empresa.Save(nombreArchivo);
    }
}
