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

    public IAlmacenamientoBBDD CreateAlmacenamientoBBDD()
    {
        return new AlmacenamientoBBDD();
    }

    public IAlmacenamientoFile CreateAlmacenamientoFile()
    {
        return new AlmacenamientoFile();
    }
}
