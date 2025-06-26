using System.Xml;

namespace XmlFiles.Write;

internal class WriteXmlFile
{
    public WriteXmlFile(string nombreArchivo)
    {
        XmlDocument? document = new();

        XmlDeclaration? xmlDeclaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement? elementRoot = document.DocumentElement;
        document.InsertBefore(xmlDeclaration, elementRoot);

        XmlElement? empresa = document.CreateElement(string.Empty, "empresa", string.Empty);
        document.AppendChild(empresa);

        for (int x = 1; x < 4; x++)
        {
            XmlElement? empleado = document.CreateElement(string.Empty, "empleado", string.Empty);
            empleado.SetAttribute("id", $"{x}");
            empresa.AppendChild(empleado);

            XmlElement? nombre = document.CreateElement(string.Empty, "nombre", string.Empty);
            XmlText? textName = document.CreateTextNode($"Empleado {x}");
            nombre.AppendChild(textName);
            empleado.AppendChild(nombre);

            XmlElement? status = document.CreateElement(string.Empty, "status", string.Empty);
            XmlText? textStatus = document.CreateTextNode("activo");
            status.AppendChild(textStatus);
            empleado.AppendChild(status);
        }

        document.Save(nombreArchivo);
    }
}
