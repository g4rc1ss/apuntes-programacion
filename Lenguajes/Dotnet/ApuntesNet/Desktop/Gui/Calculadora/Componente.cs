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
        if (Tipo == 0)
        {
            return null;
        }
        else if (Tipo == 1)
        { //Numeros
            cajaDeTexto.Text += Content;
            return cajaDeTexto.Text;
        }
        else if (Tipo == 2)
        { //Operacion
            return Content?.ToString() ?? string.Empty;
        }
        else if (Tipo == 3)
        { //Vaciar
            cajaDeTexto.Text = "";
            return cajaDeTexto.Text;
        }
        return null;
    }
}
