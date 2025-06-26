using AbstractMethod.Api;
using AbstractMethod.BaseDatos;
using AbstractMethod.File;

namespace AbstractMethod;

internal interface IFactoriaAbastracta
{
    IAlmacenamientoBbdd CreateAlmacenamientoBbdd();
    IAlmacenamientoFile CreateAlmacenamientoFile();
    IAlmacenamientoApi CreateAlmacenamientoApi();
}
