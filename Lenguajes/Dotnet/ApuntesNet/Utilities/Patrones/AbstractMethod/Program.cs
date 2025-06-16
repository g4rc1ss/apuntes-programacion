using AbstractMethod;

FactoriaAbstracta? factoria = new();

factoria.CreateAlmacenamientoApi().Guardar("objeto de api");
factoria.CreateAlmacenamientoFile().Guardar("Objeto de File");
factoria.CreateAlmacenamientoBbdd().Guardar("Objeto de BBDD");

Console.ReadKey();
