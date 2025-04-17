# Explorar las Azure Functions
Azure Functions es una solucion serverless que tiene como intencion la necesidad de escribir menos codigo, menos mantenimiento de infraestructura y ahorrar en costes.

Es comun crear sistemas para reaccionar a una serie de eventos como, por ejemplo, responder a cambios en una BBDD, procesar flujos de datos, etc

Az Functions admite una serie de **Triggers** que son formas de iniciar la ejecucion del codigo.

### Azure Functions vs Azure Logic Apps
Azure functions es un servicio totalmente serverless, mientras que logic apps es una plataforma de integracion de fujos de trabajo serverless.

| Tema | Azure Functions | Azure Logic Apps |
| --- | --- | --- |
| Desarrollo | Orientado a codigo | Orientado a diseñador |
| Conectividad | Una docena de tipos de enlaces integrados | Muchos conectores y creacion de conectores personalizados |
| Acciones | Cada actividad es una funcion, se pueden crear Activity Funcions | Gran coleccion de acciones listas para su uso |
| Supervision | Insights | Azure portal con Azure Monitor |
| Administracion | REST API, IDEs | Azure portal, REST, Powershell, IDEs |
| Contexto de ejecucion | Azure o local | Azure o local |

### Azure Functions vs Azure WebJobs
Azure WebJobs es un servicio code first. Ambos se basan en Azure App Service

| Factor | Funciones | Azure WebJobs |
| --- | --- | --- |
| Serverless con autoscale | SI | NO |
| Desarrollo y pruebas | SI | NO |
| Precio por consumo | SI |  NO|
| Integracion Logic Apps | SI | NO |
| Triggers | Temporizador </br> Blobs y colas de Azure Storage </br> Colas y temas de Azure Service Bus </br> Azure Cosmos DB </br> Azure Event Hubs </br> HTTP/WebHook </br> Azure Event Grid | Temporizador </br> Blobs y colas  de Azure Storage </br> Colas y temas de Azure Service Bus </br> Azure Cosmos DB </br> Azure Event Hubs </br> Sistema de archivos |

## Comparacion de opciones de hospedaje
Cuando creamos una Azure Function, tenemos que elegir entre diferentes planes:

| Opcion | Service | Disponibiilidad | Compatibilidad con contenedores |
| --- | --- | --- | --- |
| Plan de consumo | AZ Function | Disponible en general | NO |
| Plan de consumo flex | AZ Function | Vista previa | NO |
| Plan Premium | AZ Function | GA | Linux |
| Plan dedicado | AZ Function | GA | Linux |
| Container App | Az Container app | GA | Linux |

La infra de Azure App Service permite el hospedaje de las function en maquinas virtuales Linux y Windows. El plan dicta:
- Como se escala las function
- Los recursos disponibles en cada instancia
- Compatibilidad con funcionalidad avanzada como Azure Virtual Network
- Compatibilidad con contenedores linux

### Informacion general sobre los planes:
- **Plan de consumo**: 
  - Pagas por los recursos del proceso cuando se ejecutan(pago por uso)
  - Escalado automatico
  - Las instancias se agregan o eliminan de forma dinamica en funcion de la carga de eventos

- **Plan consumo flexible**
    - Alta escalabilidad
    - Redes virtuales
    - Pago por uso
    - Se pueden evitar los arranques en frio teniendo siempre instancias listas

- **Plan Premium**
    - Escalado automatica segun demanda
    - Siempre activo
    - Considerarlo cuando:
        - La aplicacion se ejecuta de forma continua
        - Queremos tener mas control sobre las instancias
        - Tenemos un gran volumen de ejecuciones pequeñas y una factura alta
        - Necesitamos mas CPU o Memoria
        - El codigo debe ejecutarse mas tiempo del maximo permitido
        - Queremos redes virtuales
        - Queremos usar una imagen personalizada

- **Plan dedicado**
    - Buen plan cuando necesitamos ejecuciones prologadas y las durable functions no son una opcion
    - Considerarlo cuando:
        - Necesitamos una facturacion mas predecible
        - Queremos ejecutar varias aplicaciones web y funciones en el mismo plan
        - Necesitamos tamaño de proceso mas grande
        - Queremos aislamiento de proceso completo y acceso seguro a la red
        - Uso elevado de memoria y gran escala(ASE)

- **Container App**
    - Crea e implementa funciones en Az Container Apps
    - Considerarlo cuando:
        - Queremos migrar la ejecucion de codigo desde aplicaciones heredadas a microservicios
        - Evitar la sobrecarga y complejidad de k8s
        - Necesitamos potencia y procesamiento de gama alta

### Duracion del tiempo de espera de una function
La propiedad `functionTimeout` de `host.json` especifica la duracion del tiempo de espera de las funciones.

Una vez se desencadena la ejecucion de la funcion, esta tiene que terminar en el plazo de tiempo siguiente:

| Plan | Valor predeterminado | Maximo |
| --- | --- | --- |
| Plan de consumo | 5 minutos | 10 minutos |
| Plan de consumo flexible | 30 minutos | Ilimitados |
| Plan Premium | 30 minutos | Ilimitados |
| Plan dedicado | 30 minutos | Ilimitados |
| Plan de contenedor | 30 minutos | Ilimitados |


## Escalado de Azure Functions
En la tabla se comparan los comportamientos de escalado de los diferentes planes de Azure Functions:

| Plan | Escalado Horizontal | Max Instancias |
| --- | --- | --- |
| Plan de consumo | Controlado por eventos. La infra escala CPU y memoria en funcion del numero de eventos | Windows: 200 </br> Linux: 100 |
| Plan de consumo flexible | Escalado por funcion | Limitado por el uso total de memoria |
| Plan Premium | Controlado por eventos | Windows: 1000 </br> Linux: 20-100 |
| Plan dedicado | Escalabilidad manual o automatica | 10-30 </br> 100(ASE) |
| Plan de contenedor | Controlado por eventos | 10-300 |

