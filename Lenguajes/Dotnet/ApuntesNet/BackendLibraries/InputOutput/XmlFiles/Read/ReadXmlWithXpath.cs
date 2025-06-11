using System.Xml.XPath;

namespace XmlFiles.Read;

internal class ReadXmlWithXpath
{
    public ReadXmlWithXpath(string nombreArchivo)
    {
        XPathDocument? document = new(nombreArchivo);
        XPathNavigator? navigator = document.CreateNavigator();

        XPathNodeIterator? nodes = navigator.Select("/empresa");
        nodes.MoveNext();
        XPathNavigator? nodesNavigator = nodes.Current;

        XPathNodeIterator? nodesText = nodesNavigator.SelectDescendants(
            XPathNodeType.Element,
            false
        );

        while (nodesText.MoveNext())
        {
            Console.WriteLine($"{nodesText.Current.Name} : {nodesText.Current.Value}");
        }
    }
}
