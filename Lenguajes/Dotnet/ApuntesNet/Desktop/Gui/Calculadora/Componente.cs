using System.ComponentModel;
using Avalonia.Controls;

namespace Calculadora;

public class Componente : Button
{
    public Componente() { }

    [Category("Opcion")]
    public int Tipo { set; get; }

    public string Accion(TextBox cajaDeTexto)
    {
        switch (Tipo)
        {
            case 0:
                return null;
            case 1: //Numeros
                cajaDeTexto.Text += Content;
                return cajaDeTexto.Text;
            case 2: //Operacion
                return Content?.ToString() ?? string.Empty;
            case 3: //Vaciar
                cajaDeTexto.Text = "";
                return cajaDeTexto.Text;
            default:
                return null;
        }
    }
}
