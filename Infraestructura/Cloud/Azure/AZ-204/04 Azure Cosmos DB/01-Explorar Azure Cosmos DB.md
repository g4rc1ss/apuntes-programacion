## Ventajas de Az Cosmos DB 
Cosmos es una base de datos NoSQL totalmente distribuida diseñada para proporcionar una latencia baja, escalabilidad elastica y semantica bien difinida para la coherencia de datos.

Se puede configurar para distribuirla de forma global y esta disponible en todas las regiones de Azure.
> Para tener la menor latencia, se recomienda que la base de datos se encuentre en la misma region que la aplicacion.

Con el protocolo de replicacion multimaestro, todas las regiones admiten escrituras y lecturas, esta tambien habilita:
- Escalabilidad de escritura y lectura elastica ilimitada
- 99,999% de disponibilidad
- Garantia de lecturas y escrituras atendidas en menos de 10ms en percentil 99

La aplicacion puede realizar las escrituras y lecturas practicamente en tiempo real. De forma interna, Cosmos controla la replicacion de los datos entre regiones para garantizar la coherencia de los datos.

## Exploración de la jerarquia de recursos
La cuenta de cosmos es la unidad fundamental de distribucion global y alta disponibilidad. Cosmos contiene un DNS unico y se puede administrar desde Azure portal, CLI o SDKs.
Para distribuir globalmente los datos y el rendimiento entre varias regiones, se pueden agregar o eliminar en cualquier momento.

### Elementos de una cuenta de Azure
En Cosmos, un contenedor es la unidad fundamental de escalabilidad. Practicamente se puede tener una cantidad de RUs y almacenamiento ilimitados. Azure realiza particiones de forma transparente en el contenedor mediante la Partition Key que se especifique.

Actualmente, puede crear un maximo de 50 cuentas de cosmos en una suscripcion.

### Bases de datos
Se pueden crear una o varias bases de datos. Esto no deja de ser un espacion de nombres y es la unidad de administracion de los contenedores.

### Contenedores
Un container de Cosmos DB es donde se almacenan los datos. 

A diferencia de la mayoria de las bases de datos, que generalmente se escalan verticalmente, Cosmos escala Horizontalmente.

Los datos se almacenan en uno o varios servidores denominados *particiones*. Para aumentarlas, aumenta el rendimiento o aumenta automaticamente a medida que sube el almacenamiento.

Al crear un contenedor, se debe especificar una partition key. Esta es una propiedad de los datos para ayudar a cosmos a distribuirlos. Azure usa el valor de esta propiedad para enrutar los datos a la particion adecuada. Tambien se puede usar en la clausula `WHERE` para hacer las `SELECT` mas eficaces.

El mecanismo de almacenamiento para los datos es llamada *particion fisica*. Estas pueden tener una capacidad de 10.000 Request/s y almacenan hasta 50GB. Cosmos abstrae este concepto con las particiones logicas, que pueden almacenar hasta 20GB de datos.

Al crear los contenedores se debe configurar el rendimiento:

- **Rendimiento dedicado**: El rendimiento en un contenedor se reserva exclusivamente para ese contenedor. Hay 2 tipos: Estandar y escalabilidad automatica.
- **Rendimiento compartido**: El rendimiento se especifica en el nivel de Base de datos y se comparte con hasta 25 contenedores. El uso compartido excluye los contenedores que han sido ya configurados para rendimiento dedicado.

