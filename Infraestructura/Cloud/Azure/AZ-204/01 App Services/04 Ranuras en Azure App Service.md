# Slots App Service
Los planes **Estandar, Premium y Aislado** admiten la implementacion de un slot para implementar la app en un entorno de ensayo donde poder hacer pruebas, etc.

La implementacion en un espacio que no es produccion permite.
- Validar cambios antes de establecerlos en PRO
- Disponer de un paso intermedio que elimina tiempos de inactividad, carga, etc. Simplemente se crea la instancia, se valida que funcione correctamente y se hace un redirect del trafico
- Despues del swap, el codigo, etc. Que estaba en PRO, ahora pasa a estar en el slot de deploy, por tanto, si hay algun problema, se puede volver al version anterior en poco tiempo y sabiendo que esa funciona

## Comprobacion de Swapping de Slots
Al cambiar entre slots el app service completa el proceso siguiente para ganantizar que no haya indisponibilidad:

1. Aplica configuraciones:
    - Configuraciones de la app y cadenas de conexion
    - Configuracionn de CD
    - Configuracion de auth
2. Espera que el slot se haya reiniciado. Si este no se puede realizar, se revierten los cambios y se detiene el proceso
3. Si tiene local cache, se inicializa con una solicitud HTTP("/") en cada instancia
4. Si el swap automatico esta habilitado, se inicializa la aplicacion con una peticion HTTP a raiz
5. Si todas las instancias estan preparadas, las intercambia

Durante el intercambio todo el trabajo de inicializacion se realiza en el slot origen. El destino permanece on line mientras se prepara todo.

Configuraciones que se intercambian:
<table>
<thead>
<tr>
<th>Aplican</th>
<th>No aplican</th>
</tr>
</thead>
<tbody>
<tr>
<td>Configuración general: por ejemplo, versión de Framework, 32 o 64 bits, Web Sockets</td>
<td>Extremos de publicación</td>
</tr>
<tr>
<td>Configuración de la aplicación (puede configurarse para ajustarse a un espacio)</td>
<td>Nombres de dominio personalizados</td>
</tr>
<tr>
<td>Cadenas de conexión (puede configurarse para ajustarse a un espacio)</td>
<td>Certificados no públicos y configuración de TLS/SSL</td>
</tr>
<tr>
<td>Asignaciones de controlador</td>
<td>Configuración de escala</td>
</tr>
<tr>
<td>Certificados públicos</td>
<td>Programadores de WebJobs</td>
</tr>
<tr>
<td>Contenido de WebJobs</td>
<td>Restricciones de IP</td>
</tr>
<tr>
<td>Conexiones híbridas *</td>
<td>Always On</td>
</tr>
<tr>
<td>Azure Content Delivery Network *</td>
<td>Configuración del registro de diagnóstico</td>
</tr>
<tr>
<td>Puntos de conexión de servicio *</td>
<td>Uso compartido de recursos entre orígenes (CORS)</td>
</tr>
<tr>
<td>Asignaciones de ruta de acceso</td>
<td>Integración de la red virtual</td>
</tr>
<tr>
<td></td>
<td>Identidades administradas</td>
</tr>
<tr>
<td></td>
<td>Configuración que termina con el sufijo <code>_EXTENSION_VERSION</code></td>
</tr>
</tbody>
</table>

## Swap de Slots
Los slots se pueden intercambiar desde la informacion general en la app.

### Intercambio manual
1. Vamos a la pagina de Slots y seleccionamos **Intercambiar**
2. Seleccionamos los espacios de "Origen" y "Destino"


## Enrutar trafico
Por defecto todas las solicitudes a la URL van al slot de produccion. No obstante se puede establecer que se enrute una parte del trafico a otro slot.

### Enrutamiento automatico del trafico de produccion
Para enrutar el trafico de pro automaticamente:
1. Vamos al a pagina de recursos de la aplicacion y en **Espacios de implementacion**
2. En la columna de trafico % del slot, indicamos el porcetaje(entre 0 y 100)



