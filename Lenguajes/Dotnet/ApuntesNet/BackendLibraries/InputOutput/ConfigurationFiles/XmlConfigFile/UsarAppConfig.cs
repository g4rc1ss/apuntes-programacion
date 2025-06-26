using System.Collections.Specialized;
using System.Configuration;

namespace ConfigurationFiles.XmlConfigFile;

public class UsarAppConfig
{
    public string? LocalizacionArchivo { get; private set; }

    public void ArchivosConfiguracion()
    {
        //Se lee el archivo de configuracion app.config
        //se tiene que instalar las dependencia NuGet "System.Configuration.ConfigurationManager"
        NameValueCollection? archivoConfiguracion = ConfigurationManager.AppSettings;
        LocalizacionArchivo = archivoConfiguracion["LOCALIZACION_ARCHIVO"] ?? null;
    }
}
