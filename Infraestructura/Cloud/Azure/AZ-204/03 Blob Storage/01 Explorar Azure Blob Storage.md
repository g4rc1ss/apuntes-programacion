# Exploracion de Azure Blob Storage
Azure Blob Storage es una solucion de almacenamiento de objetos. Este, esta optimizado para almacenar grandes cantidades de datos no estructurados.

Blob Storage esta diseñado para:
- Visualizar imagenes o documentos desde un explorador.
- Almacenar archivos para acceso distribuido
- Streaming de audio y video
- Escribir en archivos de registro
- Almacenar datos de copias de seguridad y restauracion
- Almacenar datos para analisis local o servicios de Azure(Logs)

Las aplicaciones y los usuarios pueden acceder a traves de HTTP/S

### Tipos de Cuentas de almacenamiento
Azure Storage ofrece 2 niveles de rendimiento:

- **Estandar**: se trata de una cuenta de uso generan v2 y se recomienda para la mayoria de escenarios
- **Premium**: Ofrecen un mayor rendimiento mediante el uso de SSD. Se pueden elegir entre tres tipos: blobs en bloques, blobs en paginas o recursos compartidos de archivos

| Tipo de cuenta | Servicios admitidos | Redundancia | Uso |
|----------------|---------------------|------------|-----|
| V2(General) | Blob storage(incluido Data Lake) </br> Queue Storage </br> Table storage </br> y Azure Files | LRS, GRS, RA-GRS, ZRS, GZRS, RA-GZRS | Se recomienda para la mayoria de los escenarios. Si necesitamos compatibilidad con NFS en Azure files, necesitaremos el Premium. |
| Blobs en bloques (Premium) | Blob storage(Con Data Lake) | LRS y ZRS | Se recomienda en escenacios con altas tasas de transacciones que utilizan objetos pequeños o requieren baja latencia |
| Recurso compartido de archivos (Premium) | Azure files | LRS y ZRS | Se recomienda para empresas y aplicaciones de escalado de alto rendimiento |
| Blobs en paginas(Premium) | Blobs en paginas | LRS y ZRS | Tipo de cuenta solo para blobs en paginas |

- LRS: Local Redundancy Storage. Replica los datos en tres ubicaciones dentro de la misma region.
- GRS: Geo Redundancy Storage. Replica los datos en tres ubicaciones dentro de la misma region y replica los datos en una segunda region.
- RA-GRS: Read Access Geo Redundancy Storage. Replica los datos en tres ubicaciones dentro de la misma region y replica los datos en una segunda region. Permite acceso de lectura a la segunda region.
- ZRS: Zona Redundancy Storage. Replica los datos en tres ubicaciones dentro de la misma region.
- GZRS: Geo Zone Redundancy Storage. Replica los datos en tres ubicaciones dentro de la misma region y replica los datos en una segunda region. Replica los datos en tres ubicaciones dentro de la misma region.
- RA-GZRS: Read Access Geo Zone Redundancy Storage. Replica los datos en tres ubicaciones dentro de la misma region y replica los datos en una segunda region. Permite acceso de lectura a la segunda region.

### Niveles de Acceso
Se  ofrecen diferentes opciones de acceso a los datos del blob.

- **Hot**: Optimizado para el acceso frecuente a los objetos. El nivel de acceso tiene los costes mas elevados en almacenamiento, pero los mas bajos en acceso.
- **Cool**: Optimizado para grandes cantidades de datos que se acceden con poca frecuencia y que llevan menos de 30 dias. Tiene mayor coste de acceso, pero menos de almacenamiento.
- **Cold**: Optimizado para almacenar durante 90 dias datos a los que se accede con poca frecuencia. Este tiene menos costes de almacenamiento y mayor de acceso a `Cool`
- **Archive**: Solo disponible para blobs individuales. Este nivel esta optimizado para los datos que toleran horas de latencias y permanecen 180 días. Es el mas economico para almacenar datos, pero el mas costoso en acceso.


## Deteccion de tipos de recursos de Blob Storage
Blob Storage ofrece 3 tipos de recursos:
- La cuenta de almacenamiento
- Contenedor en la cuenta de almacenamiento
- Un blob en un contenedor

### Storage Accounts
Una cuenta de almacenamiento tiene un namespace unico en Azure. Cada objeto que se almacena tiene una dirección que incluye el nombre del acuenta.

`http://mystorageaccount.blob.core.windows.net`

### Containers
Un contenedor organiza un conjunto de blobs, similar a un directorio de un FileSystem. Una Storage Account puede tener contendores ilimitados.

Un nombre de contenedor debe tener un nombre DNS valido:
- Debe tener entre 3 y 63 caracteres
- Debe contener solo letras minusculas, numeros y guiones
- No se permiten 2 o mas guiones consecutivos
- Debe comenzar con una letra o numero

`https://myaccount.blob.core.windows.net/mycontainer`

### Blobs
Azure admite 3 tipos de blobs:
- **Block blobs**: Almacena datos de hasta 190.7 TiB. Se utiliza para almacenar archivos de texto y binarios.
- **Append blobs**: Se utiliza para almacenar datos de registro. Se pueden agregar bloques a un blob existente, pero no se pueden eliminar o modificar los bloques existentes.
- **Page blobs**: Se utiliza para almacenar archivos de disco virtual. Se pueden almacenar hasta 8 TB. Se utilizan para almacenar discos duros virtuales de Azure.

`https://myaccount.blob.core.windows.net/mycontainer/myblob` o `https://myaccount.blob.core.windows.net/mycontainer/myvirtualdirectory/myblob`

## Caracteristicas de seguridad de Azure Storage
Azure Storage usa el cifrado de Servicio(SSE) para cifrar automaticamente los datos al almacenarse en la nube.

Microsoft recomienda usar el cifrado para proteger los datos en la mayoria de los escenarios. Sin embargo, los SDK para Blob y Queue Storage proporcionan cifrado desde el cliente.

### Cifrado de datos en reposo
Azure Storage cifra automaticamente los datos al guardarlos en la nube. Los datos se cifran con AES 256 egun el Estandard federal de procesamiento de informacion(FIPS) 140-2.

El cifrado esta habilitado en todas las cuentas de Storage y no se puede desactivar. Como esta activo por defecto, no hace falta aplicar y hacer nada, todo funciona de forma transparente al usuario.

No hay ningun coste adicional por el cifrado en Azure Storage.

### Administracion de claves
Los datos de una Storage nueva se cifran por defecto con claves administradas por Microsoft. No obstante tamben se pueden administrar con claves personalizadas,
- Se puede especificar una clave administrada por el cliente que se usara para cifrar y descifrar los datos en Blob y Azure Files. Estas claves se deben almacenar por Key Vault o en HSM.
- Se puede especificar una clave proporcionada por el cliente en las operaciones de Blob. Un cliente puede incluir una clave en la solicitud de lectura o escritura.

| Parametro de Administracion | Administradas por Microsoft | Administradas por cliente | Proporcionadas por Cliente |
|-----------------------------|-----------------------------|---------------------------|----------------------------|
| Operacion de cifrado y descifrado | Azure | Azure | Azure |
| Servicios de Storage | All | Blob y Azure Files | Blob Storage |
| Almacenamiento de Claves | Almacen de claves | Key Vault o HSM Key Vault | Propio almacen de cliente |
| Rotacion de claves | Microsoft | Customer | Customer |
| Control de Claves | Microsoft | Customer | Customer |
| Ambito de Clave | Cuenta, container o blob | Cuenta(por defecto), Container o blob | N/D |

### Cifrado de Cliente
Los SDK admiten el cifrado de datos dentro de las apps de cliente antes de cargarlos en Azure y el descifrado mientras se descargan.
- La V2 usa AES con GCM
- La V1 usa AES con CBC


