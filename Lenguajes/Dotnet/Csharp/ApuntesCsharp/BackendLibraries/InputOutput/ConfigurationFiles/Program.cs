using ConfigurationFiles.JsonConfigFile;
using ConfigurationFiles.XmlConfigFile;

// Usamos un archivo de configuracion
UsarAppConfig? localizacionArchivoAppConfig = new();
localizacionArchivoAppConfig.ArchivosConfiguracion();
Console.WriteLine(localizacionArchivoAppConfig.LocalizacionArchivo);

Console.WriteLine(
    "---------------------------------------------------------------------------------------"
);

UsarAppSettingsJson? localizacionArchivoAppSettings = new();
localizacionArchivoAppSettings.ArchivosConfiguracion();
Console.WriteLine(localizacionArchivoAppSettings.LocalizacionArchivo);
