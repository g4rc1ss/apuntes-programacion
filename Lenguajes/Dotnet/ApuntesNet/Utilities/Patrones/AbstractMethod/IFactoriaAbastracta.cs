using AbstractMethod.Api;
using AbstractMethod.BaseDatos;
using AbstractMethod.File;

namespace AbstractMethod;

internal interface IFactoriaAbastracta
{
    IAlmacenamientoBBDD CreateAlmacenamientoBBDD();
    IAlmacenamientoFile CreateAlmacenamientoFile();
    IAlmacenamientoApi CreateAlmacenamientoApi();
}
