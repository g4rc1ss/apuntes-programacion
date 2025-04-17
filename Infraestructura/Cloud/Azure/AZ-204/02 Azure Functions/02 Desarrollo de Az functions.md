# Desarrollo de Azure Functions
Una aplicación de función se compone de una o varias funciones individuales que se administran, implementan y escalan de forma conjunta. Todas las funciones comparten el mismo plan de precios, el mismo metodo de implementacion y la misma version del runtime.

## Desarrollo y comprobación de las funciones
Se pueden desarrollar Az Functions en local con IDEs, conectarse a recursos externos y depurarlas completamente.

La forma de desarrollo dependerá del lenguaje de implementacion.

Las funciones tienen 2 archivos independientemente del proyecto:
- `host.json`
- `local.settings.json`

Las configuraciones globales se indican en `host.json` y se aplican a todas las funciones

El archivo `local.settings.json` almacena la configuracion de la aplicacion, como el `appsettings.json` de .NET.
> Por recomendacion este archivo es solo para local y no se deberia de subir a un repositorio remoto, en las ultimas versiones se pueden usar secrets

## Crear Triggers y Bindings
Un trigger define como se invoca la funcion y cada funcion debe tener exactamente un trigger.

Un binding es una forma de conectar otro recurso externo a la funcion

### Definir Triggers y Bindings
| Lenguaje | Configurar por... |
| -------- | ----------------- |
| C#       | Decoradores en metodos y parametros con atributos |
| Java     | Decoradores con anotaciones |
| JavaScript/Powershell/Python | Actualizacion del esquema function.json |

Para los lenguajes que dependen de *function.json* el portal proporciona una interfaz de usuario para modificarlo.

```json
{
    "dataType": "binary",
    "type": "httpTrigger",
    "name": "req",
    "direction": "in"
}
```
Otras opciones para `dataType` son: `stream` y `string`

### Bindings
Todos los bindings tiene la propiedad `direction` en el archivo `function.json` que indica si es de entrada o salida.
- Los triggers siempre son de entrada
- Los enlaces de entrada usan `in` y los de salida usan `out`
- Algunos bindings admiten una direccion especial `inout`

**Ejemplo de trigger y binding en Azure Function**

```json
{
  "disabled": false,
    "bindings": [
        {
            "type": "queueTrigger",
            "direction": "in",
            "name": "myQueueItem",
            "queueName": "myqueue-items",
            "connection":"MyStorageConnectionAppSetting"
        },
        {
          "tableName": "Person",
          "connection": "MyStorageConnectionAppSetting",
          "name": "tableBinding",
          "type": "table",
          "direction": "out"
        }
  ]
}
```
**Ejemplo de C#**
```csharp
public static class QueueTriggerTableOutput
{
    [FunctionName("QueueTriggerTableOutput")]
    [return: Table("outTable", Connection = "MY_TABLE_STORAGE_ACCT_APP_SETTING")]
    public static Person Run(
        [QueueTrigger("myqueue-items", Connection = "MY_STORAGE_ACCT_APP_SETTING")]JObject order,
        ILogger log)
    {
        return new Person() {
                PartitionKey = "Orders",
                RowKey = Guid.NewGuid().ToString(),
                Name = order["Name"].ToString(),
                MobileNumber = order["MobileNumber"].ToString() };
    }
}

public class Person
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Name { get; set; }
    public string MobileNumber { get; set; }
}
```

## Conexión de funciones a otros recursos
Como procedimiento de seguridad, AZ Function aprovecha la funcionalidad de App Service para almacenar las cadenas, claves y tokens de forma segura para conectar con otros servicios. La configuracion siempre se almacena cifrada y para acceder a ella se hace por medio de variables de entorno.

### Configuracion de Identity
Las conexiones basadas en identidades usan una identidad administrada. Esta es asignada por el sistema, aunque se puede especificar con las propiedades `credential`y `clientID`.

Las identidades deben tener permisos para realizar acciones previstas. Esto se hace mediante la asignacion de un rol RBAC de Azure o la identidad en una directiva de acceso.

