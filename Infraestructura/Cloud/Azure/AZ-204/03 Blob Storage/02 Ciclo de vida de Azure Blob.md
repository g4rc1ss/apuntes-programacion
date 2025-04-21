# Explorar Ciclo de Vida de Azure Blob Storage
En general las personas acceder con frecuencia a algunos datos. Pero con el tiempo, suele descender. Otros datos expiran en dias o meses y hay los que se modifican o leen de forma activa en todo su ciclo de vida.

### Niveles de acceso
- **Hot**: Se usa para almacenar datos que se acceden con frecuencia
- **Cool**: Nivel optimizado paar almacenar datos que se accede con poca frecuencia y se almacena un mínimo de 30 días
- **Cold**: Nive de aceso con poca frecuencia y se almacena un mínimo de 90 días
- **Archive**: Un nivel sin conexión que almacena datos que se acceden pocas o ninguna vez, se almacenan durante 180 días con latencias flexibles que pueden durar incluso horas

### Administración del ciclo de vida de los datos
Blob Storage ofrece una directiva basada en reglas que se pueden usar para transladar los blobs al nivel de acceso adecuado e incluso que expiren al final de su ciclo de vida.

La directiva de administración permite:
- Modificar el nivel **cool** a **hot** cuando se accede a los datos
- Realizar la transicion de versiones actuales, anteriores o instantaneas de un blob a un almacenamiento **cool** si no se acceden durante un tiempo
- Eliminar las versiones actuales, antiguas o instantaneas de un blob al final del ciclo de vida
- Aplicar reglas a toda la cuenta de almacenamiento, contenedores o subconjuntos de blobs mediate el uso de prefijos o tags como filtros

Por ejemplo, un escenario donde accedemos de forma frecuente a los datos los primeros dias, pero al de 2 semanas accedemos de forma ocasional. Despues del un mes ya casi no accedemos a los datos. El mejor plan es, durante los primeros dias un acceso **Hot**, modificarlo a **Cool** cuando el acceso es ocasional y al del mes pasarlo a **archive** o **cold** segun requisitos de negocio

## Detección de directivas de ciclo de vida de Blob Storage
Una directiva es un conjunto de reglas en un documento JSON.

```json
{
  "rules": [
    {
      "name": "rule1",
      "enabled": true,
      "type": "Lifecycle",
      "definition": {...}
    },
    {
      "name": "rule2",
      "type": "Lifecycle",
      "definition": {...}
    }
  ]
}
```
- **Rules**: Se requiere al menos una regla en una directiva. Se puede definir hasta 100
    - **Name**: Nombre de la regla. Se requiere un nombre unico para cada regla, hasta 256 caracteres alfanumericos y distingue mayusculas de minusculas
    - **Enabled**: Indica si la regla esta habilitada o no.
    - **Type**: Tipo de regla. Se requiere un valor de tipo **Lifecycle**
    - **Definition**: Cada defiinicion se compone de un conjunto de filtros y acciones

### Reglas 
Cada definicion de regla incluye un conjunto de filtros y de acciones. Los filtros limitan las acciones de la regla en un determinado conjunto de objetos dentro de un contenedor o nombres de objetos.

La siguiente regla por ejemplo, filtra para ejecutar las acciones en objetos dentro de `sample-container` y empiezan por `blob1`

- Establece el nivel de blob **cool** 30 días despues de la ultima modificacion
- Establece el nivel de blob **archive** 90 días despues de la ultima modificacion
- Elimina el blob 2555(7 años) despues de la ultima modificacion
- Elimina instantaneas de blobs 90 días despues de la creacion

```json
{
  "rules": [
    {
      "enabled": true,
      "name": "sample-rule",
      "type": "Lifecycle",
      "definition": {
        "actions": {
          "version": {
            "delete": {
              "daysAfterCreationGreaterThan": 90
            }
          },
          "baseBlob": {
            "tierToCool": {
              "daysAfterModificationGreaterThan": 30
            },
            "tierToArchive": {
              "daysAfterModificationGreaterThan": 90,
              "daysAfterLastTierChangeGreaterThan": 7
            },
            "delete": {
              "daysAfterModificationGreaterThan": 2555
            }
          }
        },
        "filters": {
          "blobTypes": [
            "blockBlob"
          ],
          "prefixMatch": [
            "sample-container/blob1"
          ]
        }
      }
    }
  ]
}
```

### Filtros de reglas

| Nombre | Tipo | Obligatorio |
|--------|------|-------------|
| blobTypes | Array | Compatible |
| prefixMatch | Array, cada regla puede definir hasta 10 prefijos. Un array de prefijos debe comenzar con el nombre del contenedor | No |
| blobIndexMatch | Dictionary con las condiciones clave valor de los tags de indice de blob. Hasta 10 condiciones | No |

### Acciones de Regla
Las acciones se aplican a los blobs filtrados cuando se cumple la condicion de ejecucion.

| Action | Version Actual | Instantanea | Version Anterior |
|--------|----------------|-------------|------------------|
| tierToCool | Para `blockBlob` | Compatible | Compatible |
| tierToCold | Para `blockBlob` | Compatible | Compatible |
| enableAutoTierToHotFromCool | Para `blockBlob` | No Compatible | No Compatible |
| tierToArchive | Para `blockBlob` | Compatible | Compatible |
| delete | Para `blockBlob` | Compatible | Compatible |

> Si se define mas de una accion, se aplica la mas economica. Por ejemplo, `delete` es mas barata que `tierToArchive` y esta es mas economica que `tierToCool`.


| Condicion ejecución | Valor condicion | Descripcion |
| ------------------- | --------------- | ------------ |
| daysAfterModificationGreaterThan | `int` que indica antiguedad en dias | Condicion de las acciones de blob de base |
| daysAfterCreationGreaterThan | `int` de antiguedad de días | Condicion de las acciones de instantanea |
| daysAfterLastAccessTimeGreaterThan | `int` de antiguedad de días | Condicion de version actual de un blob teniendo habilitado el seguimiento de acceso |
| daysAfterLastTierChangeGreaterThan | `int` de antiguedad de días despues del cambio de ultimo nivel de blob | Duracion minima que un blob rehidratadao se mantiene en niveles **hot**, **cool** o **cold**. Esta accion solo se aplica a `tierToArchive` |


## Implementacion de directivas de ciclo de vida
Para implementar las directivas se puede hacer desde:
- Azure Portal
- Azure PowerShell
- Azure CLI
- API REST

### Azure Portal
Hay 2 formas, con interfaz y vista de lista o con vista de codigo json.

1. Azure portal ir a `Storage accounts`
2. En Administracion de datos, seleccionar `Lifecycle management`
3. Seleccionar Code view

Este JSON es un ejemplo que mueve un blob en bloques cuyo nombre comienza con *log*
```json
{
  "rules": [
    {
      "enabled": true,
      "name": "move-to-cool",
      "type": "Lifecycle",
      "definition": {
        "actions": {
          "baseBlob": {
            "tierToCool": {
              "daysAfterModificationGreaterThan": 30
            }
          }
        },
        "filters": {
          "blobTypes": [
            "blockBlob"
          ],
          "prefixMatch": [
            "sample-container/log"
          ]
        }
      }
    }
  ]
}
```

### Azure CLI
```bash
az storage account management-policy create --account-name <storage-account> --policy @policy.json --resource-group <resource-group>
```

## Rehidratacion de blobs desde el nivel de archivo
Mientrar un blob se encuentra en el nivel de *archive*, se considera que esta sin conexión y no se pueden leer ni modificar. Para ello primero se debe rehidratar

- **Copiar un blob archivado en un nivel en línea**: Se puede rehidratar copiando el blob en un nivel de acceso **Hot** o **Cool** con la operación `Copy Blob`o `Copy Blob from URL`. Es la opción recomedada por Microsoft en general
- **Cambio de nivel de acceso de un blob a online**: Se puede modificar directamente el nivel con la operación `Set Blob tier`

### Prioridad de la rehidratación
Al rehidratar un blob se puede establecer la prioridad de la operacion a traves del encabezado `x-ms-rehydrate-priority`
- **Standard**: La solicitud se procesa y puede tardar hasta 15 horas
- **High**: La solicitud tiene mayor prioridad y deberia completarse en menos de 1h para objetos menos a 10GB

### Copiar un blob archivado a otro nivel
Al copiar un blob archivado a un nivel en línea, se debe de copiar con un nombre diferente o en un contenedor diferente. No se puede sobreescribir el blob de origen.

A partir de la version 2021-02-12 se puede rehidratar un blob archivado copiandolo en otra cuenta siempre y cuando al cuenta de destino este en la misma region que la origen.

### Cambiar el nivel de acceso de un blob
Una vez que se inicia no se puede cancelar. El nivel de acceso continua en *archive* hasta que se modifica correctamente.

> **IMPORTANTE**: Cambiar el nivel no afecta a la hora de última modificación.

