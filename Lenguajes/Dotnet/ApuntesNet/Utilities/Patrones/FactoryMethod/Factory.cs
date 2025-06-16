using FactoryMethod.Storage;

namespace FactoryMethod;

internal static class Factory
{
    public static IAlmacenamiento GetAlmacenamientoBaseDatos()
    {
        return new AlmacenamientoBbdd();
    }

    public static IAlmacenamiento GetAlmacenamientoFile()
    {
        return new AlmacenamientoFile();
    }
}
