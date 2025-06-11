using XmlFiles.Read;
using XmlFiles.Write;

const string NOMBRE_ARCHIVO_XML = "archivo.xml";
const string NOMBRE_ARCHIVO_XML_LINQ = "archivoLinq.xml";

try
{
    _ = new WriteXmlFile(NOMBRE_ARCHIVO_XML);
    Console.WriteLine("Archivo XML Creado");

    Console.WriteLine("\n--------------------------------------------------------------------\n");
    _ = new WriteXmlWithLinq(NOMBRE_ARCHIVO_XML_LINQ);
    Console.WriteLine("Archivo LINQ XML Creado");

    Console.WriteLine("\n--------------------------------------------------------------------\n");
    _ = new ReadXmlFile(NOMBRE_ARCHIVO_XML);

    Console.WriteLine("\n--------------------------------------------------------------------\n");
    _ = new ReadXmlWithLinq(NOMBRE_ARCHIVO_XML);

    Console.WriteLine("\n--------------------------------------------------------------------\n");
    _ = new ReadXmlWithXpath(NOMBRE_ARCHIVO_XML);
}
finally
{
    Console.WriteLine("\n--------------------------------------------------------------------\n");
    Console.WriteLine("XML FINAL");
    Console.WriteLine(File.ReadAllText(NOMBRE_ARCHIVO_XML));
    File.Delete(NOMBRE_ARCHIVO_XML);

    Console.WriteLine("\n--------------------------------------------------------------------\n");
    Console.WriteLine("XML LINQ FINAL");
    Console.WriteLine(File.ReadAllText(NOMBRE_ARCHIVO_XML_LINQ));
    File.Delete(NOMBRE_ARCHIVO_XML_LINQ);
}
