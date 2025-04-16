# Configurar Aplicaciones web

## Configuración de la aplicación

Para establecer las variables de entorno, en el recurso de app service, hay una opción llamada `Variables de entorno`.
> En un Appsettings.json las variables de entorno se establecen como objetos que tienen propiedades y para leerlas se hace como `Application:data`, esa separacion en el caso de las variablesd entorno hay que hacerlas con `__`, en este caso quedaria `Application__data`.

Hay una opción para establecer las cadenas de conexión, por defecto esas variables se registran como 'ConnectionStrings__<ConnectionName>'.

Para configurar las variables de entorno, se puede hacer desde el portal de Azure, desde la CLI o desde el ARM template.
### CLI
```bash
az webapp config appsettings set --name <app_name> --resource-group <resource_group> --settings <key>=<value>
```

## Configurar las opciones generales
En **Configuration > General settings** se pueden establecer las opciones generales de la aplicación, como el framework, la versión del framework, la plataforma (32 o 64 bits), el modo de arranque (Always on) y el tipo de pila (Stack).

- **Configuration de Pila**: Se pueden establecer la version de los SDK de algunos lenguajes como .net, java, etc.

- **Configuración de plataforma**:
    - **Valor de bits**: 32 o 64 bits(Solo esta disponible en Windows).
    - **Estado FTP**: Permitir FTPS o desactivar
    - **Version Http**: Permitir HTTP 1.1 o HTTP 2.0
    - **Sockets**: Para SignalR o Socket.io
    - **Always On**: Mantiene la app escalado a 1 instancia para evitar el arranque en frio. Si esta desactivado, la aplicacion se escala a 0 cuando no recibe peticion en 20 minutos
    - **Afinidad ARR**: En una implementacion de varias instancias, asegurarse que el cliente esté enrutado a la misma vida de sesión.
    - **Solo HTTPS**: Todo el trafico se redirige a HTTPS.
    - **Version minima de TLS**: Establacer una version de cifrado minima
    - **Depuracion**: Habitlitar la depuracion remota para .NET y Node.js.  
    Esta opción se desactiva al de 48h
    - **Certificados de cliente Entrantes**: Requiere certificados en la auth mutua.


## Configurar asignaciones de ruta de acceso
En **Configuracion > Asignacion de ruta de acceso** se pueden configurar el acceso a controladores, asignar directorios y aplicaciones virtuales.

### Aplicaciones Windows(Sin contenedor)
Para aplicaciones Windows se puede personalizar el IIS, asi como las aplicaciones y directorios virtuales.

Las asignaciones permiten agregar scripts personalizados para controlar extensiones de archivo, etc. Para agregar un controlador personalizado se clicka sobre **Nuevo controlador**
- **Extension**: La extension del archivo a procesar, por ejemplo, `*.php`
- **Procesador de Scripts**: La ruta absoluta al procesador. La ruta `D:\home\site\wwwroot\` es la ruta de la aplicacion.
- **Arguments**: Argumentos adicionales.

Cada aplicación tiene la ruta de acceso raiz predeterminada(`\`) asignada a `D:\home\site\wwwroot\`.

Se pueden configurar directorios y aplicaciones virtuales especifiicando la ruta de acceso física con el directorio correspondiente. Para marcar un directorio virtual como app web, desactivar la casilla **Directorio**


### Aplicaciones Linux y en contenedor
Se puede agregar almacenamiento personalizado para los contenedores. Las apps en contenedores incluyen todas Linux y se ejecutan en app service. **Nuevo montaje de Azure Storage** y configurar el almacenamiento personalizado:

- **Nombre**: Nombre para mostrar
- **Basica o Avanzada**: Basico si la cuenta de almacenamiento **NO** usa puntos de conexion de servicio, privados o AZ Key Vault. Avanzado para el resto
- **Cuentas de almacenamiento**: Cuenta de almacenamiento con el contenedor que quiere
- **Storage type**: Azure blobs o Azure Files. Las aplicaciones contenedor Windows solo pueden usar Azure Files. Los blobs son de solo lectura
- **Contenedor de almacenamiento**: Para la basica, el contenedor que queremos
- **Nombre del recurso compartido**: Para configuraciones avanzadas
- **Clave de acceso**: para la config avanzada
- **Ruta de acceso de montaje**: Ruta absoluta al contenedor para montar el almacenamiento
- **Ranura de implementación**: Cuando se activa, la config se aplica a las ranuras de implementacion

## Registro de diagnostico
Hay diagnosticos integrados para depurar un app service.

| Tipo | Plataforma | Location | Descripción |
|------|------------|----------|-------------|
| Registro de aplicaciones | Windows, Linux | Sistema de archivos app service o blobs | Registra los mensajes generados por la aplicación. |
| Registro del servidor web | Windows | Sistema de archivos app service o blobs | Registra las solicitudes HTTP y los errores del servidor web. |
| Mensajes de error detallados | Windows | Sistema de archivos | Copias de las paginas de error devueltas por la app. |
| Seguimiento de solicitudes con error | Windows | Sistema de archivos app service| Información de seguimiento detallada sobre las solicitudes con error |
| Registro de implementacion | Windows, Linux | Sistema de archivos app service | Ayuda a determinar por que se ha producido un error en la implementación. |

### Habilitar el registro en Windows

1. En la aplicación correspondiente ir a  **Registros de App Service**.

2. Seleccionar **Activado** en **Registro de la aplicacion(Sistema de archivos)** o **Blob**, o ambos. El Sistema de archivos es para una depuracion temporal y se desactiva en 12h. El blob es para largo plazo.

3. Establecer el nivel de detalle.

### Habilitar el registro en Linux
1. En la aplicación correspondiente ir a  **Registros de App Service**.

2. En **Cuota (MB)**, especificar la cuota de disco para los registros. En **Período de retención (días)**, establecer el número de días que se conservarán los registros antes de ser eliminados.

### Habilitar en el Servidor web
1. Seleccionar **Almacenamiento** para el blob o **Sistema de archivos**.
2. Seleccionar el periodo de retencion

### Transmisión de registros
Antes de transmitir los registros en tiempo real, hay que habilitar el tipo de registro. App Service transmite cualquier archivo que termina en `.txt`, `.log` o `.htm` y que se almacena en `/LogFiles(D:\home\logfiles)`.

- Para transmitir los registros en Az Portal, en la aplicación, seleccionamos **Transmisión de registros**.
- En la CLI
```bash
az webapp log tail --name <app_name> --resource-group <resource_group>
```

### Ver los registros
- Linux o containers: `https://<app-name>.scm.azurewebsites.net/api/logs/docker/zip`
- Windows: `https://<app-name>.scm.azurewebsites.net/api/dump`

## Configuracion de certificados de seguridad
En app service se pueden crear, cargar e importar certificados privados o publicos.

Los certificados cargados en una aplicacion se almacenan en una unidad de implementacion enlazada en combinacion de region y grupo de recursos del plan. De esta forma los certificados son accesibles desde otras aplicaciones con las mismas combinaciones.

| Opcion | Descripcion |
| ------ | ----------- | 
| Crear certificado gratuito | Certificado gratis y facil de usar si solo necesitas proteger el dominio |
| Comprar certificado | Certificado privado administrado por Azure. Combina simplicidad automatizada con renovacion y exportacion |
| Importacion de Key Vault | Util si usamos Key Vault para administrar los certificados. |
| Cargar certificado privado | Importar uno ya existente de terceros |
| Cargar certificado publico | Los certificados publicos no se usan para proteger dominios, pero se pueden cargar en el codigo por si fueran necesarios para acceder a recursos remotos |

### Requisitos de Certificados privados
El certificado administrado por App Service gratuito ya cumplen los requisitos. Si se quiere usar uno privado, hay que tener en cuenta lo siguiente:
- **Formato**: PFX protegido con contraseña y cifrado Triple DES
- **Tamaño**: Que contenga una Clave privada de al menos 2048 bits
- Contiene todos los certificados intermedios y la CA raiz

Para proteger un dominio personalizado en un TLS, hay que tener en cuenta lo siguiente:
- Contener un uso mejorado de clave (OID = 1.3.6.1.5.5.7.3.1)
- Estar firmado por una CA de confianza

### Crear un certificado gratuito
Para crear enlaces TLS/SSL o habilitar certificados hay que estar en los niveles **Basico, estandar, premium o asilado**

El certificado administrado gratuito es una solucion intermedia para proteger el nombre DNS. Se trata de un certificado que se renueva de manera continua y automatica en 6 meses.

El certificado gratuito tiene las siguientes limitaciones:
- No admite certificados comodin
- No admite el uso como certificado de cliente mediante huella digital
- No admite DNS privado
- No se puede exportar
- No es compatible con App Service Environment(ASE)
- Solo admite caracteres alfanumericos, guiones y puntos
- Solo se admiten dominios personalizados de hasta 64 caracteres

### Importar un certificado
Si adquirimos un certificado de App Service de Azure, esta administra lo siguiente:
- Se ocupa del proceso de adquisición
- Realiza la comprobacion de dominio
- Mantiene el certificado en Azure Key vault
- Adminsitra la renovacion
- Sincroniza el certificado automaticamente con las copias importadas en la app service

Si ya tienes un certificado en funcionamiento:
- Importar el certificado
- Administrar el certificado, por ejemplo, renovarlo y exportarlo


