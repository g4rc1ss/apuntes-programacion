using FactoryMethod;

IAlmacenamiento? baseDeDatos = Factory.GetAlmacenamientoBaseDatos();
baseDeDatos.Guardar("entidad BBDD");

IAlmacenamiento? file = Factory.GetAlmacenamientoFile();
file.Guardar("Entidad File");

Console.ReadKey();
