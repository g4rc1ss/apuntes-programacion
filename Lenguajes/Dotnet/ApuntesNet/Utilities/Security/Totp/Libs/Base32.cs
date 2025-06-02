using System.Text;
using static Wiry.Base32.Base32Encoding;

namespace Totp.Libs;

/// <summary>
/// Clase que codifica/decodifica en Base32
/// </summary>
public class Base32
{
    /// <summary>
    /// Convierte una cadena a Base32
    /// </summary>
    /// <param name="input">Cadena de entrada</param>
    /// <returns>Cadna de salida</returns>
    public static string Encode(string input)
    {
        return Standard.GetString(Encoding.ASCII.GetBytes(input));
    }

    /// <summary>
    /// Decodifica una cadena Base32
    /// </summary>
    /// <param name="encoded">Cadena en Base32</param>
    /// <returns>Cadena original decodificada</returns>
    public static string Decode(string encoded)
    {
        return Encoding.ASCII.GetString(Standard.ToBytes(encoded));
    }
}

/// <summary>
/// Clase que codifica/decodifica en Z-Base32
/// </summary>
public class ZBase32
{
    /// <summary>
    /// Convierte una cadena a ZBase32
    /// </summary>
    /// <param name="input">Cadena de entrada</param>
    /// <returns>Cadna de salida</returns>
    public static string Encode(string input)
    {
        return Wiry.Base32.Base32Encoding.ZBase32.GetString(Encoding.ASCII.GetBytes(input));
    }

    /// <summary>
    /// Decodifica una cadena ZBase32
    /// </summary>
    /// <param name="encoded">Cadena en ZBase32</param>
    /// <returns>Cadena original decodificada</returns>
    public static string Decode(string encoded)
    {
        return Encoding.ASCII.GetString(Wiry.Base32.Base32Encoding.ZBase32.ToBytes(encoded));
    }
}
