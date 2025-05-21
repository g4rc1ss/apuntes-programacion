# Trabajo con Blob Storage

## SDK de Azure Blob Storage
En .net los SDK ofrecen objetos y caracteristicas como las siguentes:

- **BlobClient**: BlobClient permite manipular los blos de Azure Storage
- **BlobClientOptions** Proporciona las opciones de config de cliente para conectarse a blob Storage
- **BlobContainerClient** Manipula Azure Storage y sus blobs
- **BlobServiceClient** Manipula los recursos de servicio y contenedores de blobs de Azure Storage.
- **BlobUriBuilder** Proporciona una manera comoda de modificar el contenido de una instancia de URI para que apunte a diferentes recursos de Azure Storage

## Creacion un Objeto
Lo recomendable para la comunicacion con Azure es usar `DefaultAzureCredential` para todo el tema de auth a traves de **EntraId**

Para crear un blob hay que instanciar `BlobServiceClient` y permite interactuar con los recursos en el nivel de cuenta de almacenamiento. 
```csharp
using Azure.Identity;
using Azure.Storage.Blobs;

public BlobServiceClient GetBlobServiceClient(string accountName)
{
    BlobServiceClient client = new(
        new Uri($"https://{accountName}.blob.core.windows.net"),
        new DefaultAzureCredential());

    return client;
}
```

- **BlobContainerClient**: Permite interactuar con los recursos en el nivel de contenedor. Esta clase proporciona metodos para crear, eliminar o configurar contenedores, tambien para enumerar, cargar y eliminar blobs.

Creamos un objeto para interactuar con un contenedor
```csharp
public BlobContainerClient GetBlobContainerClient(
    BlobServiceClient blobServiceClient,
    string containerName)
{
    // Create the container client using the service client object
    BlobContainerClient client = blobServiceClient.GetBlobContainerClient(containerName);
    return client;
}
```

Si solo tenemos que interactuar con un contenedor concreto, podemos instanciar directamente el `BlobContainerClient` con la URI de acceso
```csharp
public BlobContainerClient GetBlobContainerClient(
    string accountName,
    string containerName,
    BlobClientOptions clientOptions)
{
    // Append the container name to the end of the URI
    BlobContainerClient client = new(
        new Uri($"https://{accountName}.blob.core.windows.net/{containerName}"),
        new DefaultAzureCredential(),
        clientOptions);

    return client;
}
```

Para obtener un blob podemos obtener `BlobClient` del container
```csharp
public BlobClient GetBlobClient(
    BlobServiceClient blobServiceClient,
    string containerName,
    string blobName)
{
    BlobClient client =
        blobServiceClient.GetBlobContainerClient(containerName).GetBlobClient(blobName);
    return client;
}
```

## Administración de metadatos y propiedades de container
Los contenedores admiten propiedades de sistema y metadatos defiinidos por el usuario

- **Propiedades del sistema**:En cada blob existen propiedades del sistema. Algunas se pueden leer o establecer, mientras que otras son de solo lectura. Los SDK mantienen las propiedades automaticamente
- **Metadatos definidos por el usuario**: Se componen de pares clave-valor que especifica para un recurso de almacenamiento. Se puede usar para almacenar otros valores con el recurso

### Recuperacion de las propiedades del contenedor
Para recuperar las propiedades del container se llama a:
- `GetProperties`
- `GetPropertiesAsync`

```csharp
private static async Task ReadContainerPropertiesAsync(BlobContainerClient container)
{
    try
    {
        // Fetch some container properties and write out their values.
        var properties = await container.GetPropertiesAsync();
        Console.WriteLine($"Properties for container {container.Uri}");
        Console.WriteLine($"Public access level: {properties.Value.PublicAccess}");
        Console.WriteLine($"Last modified time in UTC: {properties.Value.LastModified}");
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}
```

### Establecimiento y recuperación de metadatos
Se agregan los pares clave-valor enviando un objeto con `IDictionary` en los metodos
- `SetMetadata`
- `SetMetadataAsync`
```csharp
public static async Task AddContainerMetadataAsync(BlobContainerClient container)
{
    try
    {
        IDictionary<string, string> metadata =
           new Dictionary<string, string>();

        // Add some metadata to the container.
        metadata.Add("docType", "textDocuments");
        metadata.Add("category", "guidance");

        // Set the container's metadata.
        await container.SetMetadataAsync(metadata);
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}
Los metodos `GetProperties` y `GetPropertiesAsync` se usan para recuperar metadatos

```csharp
public static async Task ReadContainerMetadataAsync(BlobContainerClient container)
{
    try
    {
        var properties = await container.GetPropertiesAsync();

        // Enumerate the container's metadata.
        Console.WriteLine("Container metadata:");
        foreach (var metadataItem in properties.Value.Metadata)
        {
            Console.WriteLine($"\tKey: {metadataItem.Key}");
            Console.WriteLine($"\tValue: {metadataItem.Value}");
        }
    }
    catch (RequestFailedException e)
    {
        Console.WriteLine($"HTTP error code {e.Status}: {e.ErrorCode}");
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}
```

## Establecer y recuperar propiedades y metadatos de Blobs
Los contenedores y blobs pueden tener metadatos personalizados, que son representados como headers HTTP. Estos se pueden establecer al crear el recurso de contenedor o blob o agregandolos mas adelante.

El formato se establecen como pares clave-valor:
```
x-ms-meta-name:string-value
```
> A partir de la version 2009 los nombres deben cumplir las reglas de nomenclatura de los identificaciones de C#

### Operaciones con metadatos
Los metadatos se puede establecer o recuperar directamente sin leer o modificar el recurso en si.

Las operaciones GET y HEAD devuelven los metadatos de un blob o contenedor.
```
# Para recuperar los metadatos de un contenedor
GET/HEAD https://myaccount.blob.core.windows.net/mycontainer?restype=container

# Para recuperar los metadatos de un blob
GET/HEAD https://myaccount.blob.core.windows.net/mycontainer/myblob?comp=metadata
```

Con la operacion PUT se pueden establecer los metadatos de un blob o contenedor. 
```
# Para establecer los metadatos de un contenedor
PUT https://myaccount.blob.core.windows.net/mycontainer?comp=metadata&restype=container

# Para establecer los metadatos de un blob
PUT https://myaccount.blob.core.windows.net/mycontainer/myblob?comp=metadata
```

La diferencia entre un encabezado estandar y personalizado, entre otras cosas, es que los personalizados tienen que tener el prefijo `x-ms-meta-{nombre}`. 

Los standard headers son:

Para contenedores y Blobs:
- **ETag**
- **Last-Modified**

Para Blobs:
- **Content-Length**
- **Content-Type**
- **Content-MD5**
- **Content-Encoding**
- **Content-Language**
- **Cache-Control**
- **Origin**   
- **Range**

