namespace Composite;

public class ArticulosServicio(ILogger logger)
{
    public void GuardarArticulo(string contenido, string titulo)
    {
        logger.LogInfo($"vamos a insertar el articulo {titulo} con el contenido {contenido}");
        logger.LogInfo($"articulo {titulo} insertado");
    }

    public string ConsultarArticulo(string titulo)
    {
        logger.LogInfo($"Consultar artículo {titulo}");

        logger.LogFatal($"buscar articulo en el sistema de archivos {titulo}", null);
        return string.Empty;
    }
}
