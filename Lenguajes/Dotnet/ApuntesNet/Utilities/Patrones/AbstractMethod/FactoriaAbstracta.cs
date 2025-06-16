using AbstractMethod.Api;
using AbstractMethod.BaseDatos;
using AbstractMethod.File;

namespace AbstractMethod;

internal class FactoriaAbstracta : IFactoriaAbastracta
{
    public IAlmacenamientoApi CreateAlmacenamientoApi()
    {
        return new AlmacenamientoApi();
    }

    public IAlmacenamientoBbdd CreateAlmacenamientoBbdd()
    {
        return new AlmacenamientoBbdd();
    }

    public IAlmacenamientoFile CreateAlmacenamientoFile()
    {
        return new AlmacenamientoFile();
    }
}
