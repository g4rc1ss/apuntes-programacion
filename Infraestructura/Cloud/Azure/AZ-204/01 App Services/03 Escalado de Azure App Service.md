# Escalado de App Service
Azure app service admite 2 opciones para el escalado horizontal:
- Escalado automatico con la escalabilidad de Azure. Este toma sus decisiones en funcion de las reglas definidas,
- Escalado automatico de Azure App Service. Escala segun los parametros establecidos.

El escalado automatico es un proceso en la nube que ajusta los recursos disponibles en funcion de la demanda.

Se puede activar en funcion de una programación o evaluando si el sistema se ejecuta con recursos insuficientes. Por ejemplo, el escalado se podría activar si aumenta la CPU o la memoria.

> Las reglas del escalado automatico hay que crearlas con precaucion, puesto que si reibimos, por ejemplo, un ataque DDOS puede escalar infinito y tendremos un problema grave

### ¿Cuando consideramos el escalado automatico?
El escalado automatico proporciona elasticidad en los servicios para momentos puntuales en los que se requiere un aumento de recursos.

El escalado mejora la disponibilidad y la tolerancia a errores. Ayuda a garantizar que las solicitudes a un servicio no se denieguen porque una instancia no sea capaz de procesarlas

El escalado automatico es una opcion de escalado horizontal, que controla las decisiones de escalado de las app web con los planes de app service. Es diferente de la escalabidad ya existente que permite definir reglas de escalado basadas en programaciones y recursos.

Estas son algunas recomendaciones:
- No se recomienda configurar reglas de esclabilidad automatica basadas en metricas.
- Se recomienda que las aplicaciones en el mismo plan se escalen de forma diferente e independiente
- La aplicacion esta conectada a una base de datos o un sistema heredado. El escalado permite establecer automaticamente el num max de instancias a las que se puede escalar con el plan.


## Identificacion de factores de escalado
El escalado automatico es una caracteristica del plan de App Service que usa la app. Cuendo esta escala, Azure crea instancias nuevas del hardware definidas por el plan para la app.

Para evitar el escalado descontrolado, el plan tiene un límite de instancias. Cuanto mas caro el plan, mas numero soporta.

### Condiciones de la escalabilidad
- Escalado basado en metricas, como la cola, numero de peticiones en espera, etc.
- Escalar por programacion, por ejemplo, escalar a una hora concreta del dia, rango de fechas, dias de la semana, etc. Tambien se puede establecer una fecha de fin

Si es necesario escalar de forma incremental, se pueden combinar ambos metodos.

Escalado basado en metricas:
- **% CPU**: Esta metrica infica el uso de la CPU en todas las instancias. Un valor elevado significa que las instancias estan enlazadas a CPU y es un problema
- **% Memoria**: Indica la media de memoria de todas las instancias. Un valor elevado indica que se esta agotando
- **Cola de e/s**: Media de solicitudes de E/S pendientes
- **Http en espera**: Muestra las solicitudes pendientes de procesarse
- **Entrada de datos**: Indica el numero de bytes recibidos en todas las instancias
- **Salida de datos**: Indica el numero de bytes enviados en las instancias

Una regla de escalabilidad automatica agrega los valores recuperados en una metrica a lo largo de un periodo de tiempo(*intervalo de agregacion*), en general 1 minuto. Como se considera un valor pequeño, se establece un segundo paso que realiza una agregacion adicional de un tiempo superior(10 mins por ejemplo), a esto se le llama *duracion*

El calculo de agregacion de la *duracion* puede ser diferente al de *intervalo de agregacion*. Por ejemplo, la agregacion de tiempo es Promedio y la estadistica que se obtiene es *Porcentaje de CPU* durante 1 minuto. Si la estadistica de *intervalo de agregacion* se establece en *Max* y la *duracion* en 10 minutos, el valor maximo de los 10 valores promedio del procentaje se comprueban para ver si se ha superado el umbral


Cuando una regla detecta una metrica que supera el umbral, puede realizar la accion de escalar. pero se pueden establecer las acciones de *escalar* y *reducir*. Se pueden establecer reglas tanto para crear instancias, como para eliminarlas

### Combinacion de reglas de escalabilidad automatica
Una misma condicion puede contener varias reglas(por ejemplo, una para escalar y otra para eliminar)

Se podrian definir reglas como las siguiente:

- Si la cola HTTP es superarior a 10, escalar en 1
- Si el uso de CPU supera el 70%, escalar 1
- Si la cola HTTP es 0, reducir 1
- Si el uso de CPU es inferior al 50%, reducir.

## Habilitar el autoescalado en App Service
En app service plan seleccionamos **Escalado horizontal** en **Configuration**.

Por defecto estara establecido `manual`, indicamos el custom autoescale

- Una vez habilitado, se puede editar la condicion predeterminada y establecemos nuestras reglas

- Para crear reglas, pulsamos sobre **Add rule** y definimos los criterios necesarios

Azure permite realizar el seguimiento de cuando se escalan las instancias en el **Historial de ejecución**

## Mejores practicas para el escalado automatico
> Todos los errores y exitos se registran en el registro de actividad donde se puede configurar una alerta del registro para recibir notificacaciones, sms, etc.

- **Asegurarse de que los valores max y min son diferentes y tienen un margen adecuado**: Si el minimo es 2, el maximo 2 y hay 2 instancias, no se podra nunca escalar mas
- **Elegir la estadistica adeacuada para la metrica a diagnosticar**: La mas comun es el promedio 
- **Elegir el umbral con cuidado**:  
    - Algunas configuraciones podrian ocasionar problemas como Flapping(bucle infinito de escalado) por el tipo de valor que manejan, no es recomedable configuraciones como las siguientes
        - Incrementar instancias cuando el numero de subprocesos >= 600
        - Disminuir cuando sea <= 600
    - Se recomienda establacer un margen optimo de umbrales de ampliacion y reduccion como:
        - Aumentar cuando % CPU es > 80
        - Disminuir cuando es < a 60
- **Consideraciones para escalado con varias reglas**: El escalado ocurre si se cumple alguna de las reglas.
- **Establecer siempre un recuento de instancias por defecto**
- **Configurar notificaciones de escalado automatico**