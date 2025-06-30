using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Calculadora;

public partial class MainWindow : Window
{
    private string _operacion = "";
    private readonly int[] _numero = new int[2];
    private bool _insertar = true;
    private bool _operacionSeleccion = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Listener(object sender, RoutedEventArgs e)
    {
        Componente? compo = (Componente)sender;
        string? respuesta = compo.Accion(mostrar);

        if (ComprobarNumero(respuesta))
        {
            switch (_insertar)
            {
                case true:
                    _numero[0] = int.Parse(mostrar.Text);
                    break;
                case false:
                    _numero[1] = int.Parse(mostrar.Text);
                    break;
            }
        }
        else
        {
            switch (respuesta)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                {
                    if (string.IsNullOrEmpty(mostrar.Text))
                    {
                        // await DisplayAlert("Calc", "Calc", "Debes introducir un numero primero", "Cancel");
                        return;
                    }

                    if (_operacionSeleccion)
                    {
                        // await DisplayAlert("Calc", "Calc", "Ya has seleccionado una operacion", "Cancel");
                        return;
                    }
                    else
                    {
                        mostrar.Text = "";
                        _operacion = respuesta;
                        _insertar = false;
                        _operacionSeleccion = true;
                    }

                    break;
                }
                case "C":
                {
                    for (int x = 0; x < _numero.Length; x++)
                    {
                        _numero[x] = 0;
                    }

                    _insertar = true;
                    _operacionSeleccion = false;
                    break;
                }
                case "=" when _operacion == null:
                // await DisplayAlert("Calc", "Debes introducir otro numero", "Cancel");
                case "=" when string.IsNullOrEmpty(mostrar.Text):
                    // await DisplayAlert("Calc", "Debes seleccionar una operacion primero", "Cancel");
                    return;
                case "=":
                {
                    int resultado = Operar(_operacion);
                    mostrar.Text = "" + resultado;
                    _numero[0] = resultado;
                    _insertar = true;
                    _operacionSeleccion = false;
                    break;
                }
            }
        }
    }

    private int Operar(string operacion)
    {
        return operacion switch
        {
            "+" => _numero[0] + _numero[1],
            "-" => _numero[0] - _numero[1],
            "*" => _numero[0] * _numero[1],
            "/" => _numero[0] / _numero[1],
            _ => 0,
        };
    }

    private bool ComprobarNumero(string respuesta)
    {
        try
        {
            int.Parse(respuesta);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
