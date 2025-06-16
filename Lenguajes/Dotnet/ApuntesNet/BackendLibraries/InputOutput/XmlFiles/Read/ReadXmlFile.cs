using System.Xml;

namespace XmlFiles.Read;

internal class ReadXmlFile
{
    public ReadXmlFile(string nombreArchivo)
    {
        XmlDocument? document = new();
        document.Load(nombreArchivo);

        if (document.DocumentElement == null)
        {
            return;
        }

        foreach (XmlNode node in document.DocumentElement.ChildNodes)
        {
            string? id = node.Attributes?["id"]?.Value;
            Console.WriteLine($"Id: {id}");

            foreach (XmlNode elements in node.ChildNodes)
            {
                Console.WriteLine($"{elements.Name} : {elements.InnerText}");
            }
        }
    }
}
