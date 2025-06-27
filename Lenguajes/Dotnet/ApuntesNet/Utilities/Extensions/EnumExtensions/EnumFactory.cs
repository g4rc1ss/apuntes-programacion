using System.Reflection;

namespace EnumExtensions;

/// <summary>
/// Muchas de nuestras enumeraciones correspondería con una clave Alfanumérica, no una clave númerica.
/// Para aprovechar la comodidad del trabajo con enumeraciones se ha creado la clase EnumFactory
/// que lo que hará es dada una enumeración y un array de claves devolverá la clave correspondiente a un
/// EnumItem y vicersa.
///
/// -- R E S T R I C C I O N E S --
///
/// 1) Toda enumeración que tenga asociada una clave alfanumerica se debe crear y asociado a la misma un array
/// con las claves, que se llamará por convención CONST_NombredelaEnumeracion
///   El indice de la clave dentro del array debe corresponder con el valor de la enumeración.
/// 2) Toda enumeración de este tipo debería tener una clave Unknown = -1
/// 3) La clave asociada al EnumItem Unknown será " "
///
/// </summary>
/// <example>
///  public enum SiNo
///  {
///    Si = 0,
///    No = 1,
///    Unkwown = -1
///  }
///  public string[] CONST_Sino={"S","N"}
///
/// -- Uso --
/// EnumItemFromKey/<SiNo/>(CONST_SiNo,"S") devolverá Sino.Si
/// KeyFromEnumItem/<SiNo/>(CONST_SiNo, Sino.Si) devolverá "S"
/// EnumItemFromKey/<SiNo/>(CONST_SiNo, "J") devolverá SiNo.Unkwown
/// KeyFromEnumItem/<Sino/>(CONST_SiNo, SiNo.Unkwown) devolverá " "
/// </example>
public static class EnumFactory
{
    /// <example> Métodos sin Array de constantes
    /// <code>
    /// public enum SiNo {
    /// [EnumDescription(@"S")]
    /// Si = 0,
    /// [EnumDescription(@"N")]
    /// No = 1,
    /// [EnumDescription(@"desconocido")]
    /// desconocido = -1
    /// }
    ///
    /// -- Uso --
    /// EnumItemFromKey/<SiNo/>("S") // devolverá Sino.Si
    /// KeyFromEnumItem/<SiNo/>(Sino.Si) // devolverá "S"
    /// EnumItemFromKey/<SiNo/>("J") // devolverá SiNo.Unkwown
    /// KeyFromEnumItem/<Sino/>(SiNo.desconocido) // devolverá " "
    /// </code>
    /// </example>
    /// <summary>
    /// Devuelve el EnumItem correspondiente a una Clave
    /// </summary>
    /// <typeparam name="TEnum">Enumeración</typeparam>
    /// <param name="clave">Clave</param>
    /// <returns>EnumItem de la Enumeración TEnum que corresponde con la clave.
    ///    Si el elemento de la enumeracion tiene una descripción, se utilizará esta para
    ///    la búsqueda del elemento a devolver. En caso contrario, se utilizará la clave
    ///    del elemento de la enumeración.
    ///    (Si la clave pasada como parámetro NO ESTÁ entre los nombres y las descripciones de los elementos
    ///    de la enumeración, entonces devuelve -1 que corresponde con el valor "desconocido" de la enumeración.)
    /// </returns>
    public static TEnum EnumItemFromKey<TEnum>(string clave)
        where TEnum : struct, IConvertible
    {
        Type? enumToTranslate = typeof(TEnum);
        if (enumToTranslate.IsEnum)
        {
            foreach (object? valor in Enum.GetValues(enumToTranslate))
            {
                MemberInfo[]? miembro = enumToTranslate.GetMember(valor.ToString());
                object[]? attrs = miembro[0]
                    .GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
                string? nombre =
                    attrs.Length > 0
                        ? ((EnumDescriptionAttribute)attrs[0]).Text
                        : Enum.GetName(enumToTranslate, valor);
                if (nombre == clave)
                {
                    return (TEnum)valor;
                }
            }
        }
        return (TEnum)Enum.Parse(enumToTranslate, "-1");
    }

    /// <summary>
    /// Devuelve el EnumItem correspondiente a una Clave
    /// </summary>
    /// <typeparam name="TEnum">Enumeración</typeparam>
    /// <param name="constates">Array que contiene las claves de esa enumeración</param>
    /// <param name="clave">Clave</param>
    /// <returns>EnumItem de la Enumeración TEnum que corresponde con la clave.
    ///    (Si la clave NO ESTÁ dentro del array de constantes, entoneces devuelve -1 que
    ///    corresponde con el valor Unkwown de la enumeración.)
    /// </returns>
    public static TEnum EnumItemFromKey<TEnum>(string[] constates, string clave)
        where TEnum : struct, IConvertible
    {
        int posicion = Array.IndexOf(constates, clave);
        if (posicion < 0)
        {
            posicion = -1;
        }
        _ = Enum.TryParse(posicion.ToString(), out TEnum retorno);
        return retorno;
    }

    /// <summary>
    /// Devuelve la clave correspondiente a un EnumItem
    /// </summary>
    /// <typeparam name="TEnum">Enumeración</typeparam>
    /// <param name="enumItem">EnumItem del que se quiere conocer la clave</param>
    /// <returns>Clave asociada a ese EnumItem.
    ///   Si ese EnumItem tiene descripción asociada, se devolverá la misma, en caso contrario, la clave asociada.
    ///   Si ese EnumItem no tiene clave asociada devolverá " "
    /// </returns>
    public static string KeyFromEnumItem<TEnum>(TEnum enumItem)
        where TEnum : struct, IConvertible
    {
        string? retorno = string.Empty;
        if (!typeof(TEnum).IsEnum)
        {
            return retorno;
        }

        Type? enumToSearch = typeof(TEnum);

        foreach (object? value in Enum.GetValues(enumToSearch))
        {
            if (enumItem.Equals(value))
            {
                MemberInfo[]? m = enumToSearch.GetMember(value.ToString());
                object[]? attrs = m[0].GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
                string? key =
                    attrs.Length > 0
                        ? ((EnumDescriptionAttribute)attrs[0]).Text
                        : Enum.GetName(enumToSearch, value);
                return key == "desconocido" ? retorno : key;
            }
        }
        return retorno;
    }

    /// <summary>
    /// Devuleve la clave correspondiente a un EnumItem
    /// </summary>
    /// <typeparam name="TEnum">Enumeración</typeparam>
    /// <param name="constantes">Array que contiene las claves de esa enumeración</param>
    /// <param name="t">EnumItem del que se quiere conocer la clave</param>
    /// <returns>Clave asociada a ese EnumItem.
    ///   Si ese EnumItem no tiene clave asociada devolverá " "
    /// </returns>
    public static string KeyFromEnumItem<TEnum>(string[] constantes, TEnum t)
        where TEnum : struct, IConvertible
    {
        string? retorno = " ";
        if (!typeof(TEnum).IsEnum)
        {
            return retorno;
        }

        int num = Convert.ToInt32(t);
        return num > constantes.GetUpperBound(0) || num < constantes.GetLowerBound(0)
            ? retorno
            : constantes[num];
    }

    /// <summary>
    /// Hace más facil la conversión de un texto a su correspondiente valor en una enumeración
    /// </summary>
    /// <typeparam name="TEnum">Enumeración a la que convertir. El tipo</typeparam>
    /// <param name="value">Valor a convertir. no se diferencia entre mayúsculas y minúsculas</param>
    /// <returns>Valor de la enumeración correspondiente</returns>
    /// <exception cref="ArgumentException">Si el valor a copnvertir no se encuentra en la enumeración</exception>
    /// <exception cref="ArgumentNullException">Si el valor a copnvertir es null</exception>
    public static TEnum ParseEnum<TEnum>(string value)
        where TEnum : struct, IConvertible
    {
        return value == null ? throw new ArgumentNullException(nameof(value))
            : !Enum.TryParse(value, true, out TEnum retorno)
                ? throw new ArgumentException("El valor no existe en la enumeración", nameof(value))
            : retorno;
    }

    /// <summary>
    /// Hace más facil la conversión de un texto a su correspondiente valor en una enumeración. Admite valores nulos
    /// </summary>
    /// <typeparam name="TEnum">Enumeración a la que convertir. El tipo</typeparam>
    /// <param name="value">Valor a convertir. no se diferencia entre mayúsculas y minúsculas y se admiten nulos</param>
    /// <returns>Valor de la enumeración correspondiente o nada si el valor de entrada es null</returns>
    /// <exception cref="ArgumentException">Si el valor a copnvertir no se encuentra en la enumeración</exception>
    public static TEnum? ParseEnumNullable<TEnum>(string value)
        where TEnum : struct, IConvertible
    {
        return value == null ? null
            : !Enum.TryParse(value, true, out TEnum retorno) ? null
            : retorno;
    }

    /// <summary>
    /// Hace más facil la conversión de un texto a su correspondiente valor en una enumeración
    /// </summary>
    /// <typeparam name="TEnum">Enumeración a la que convertir. El tipo</typeparam>
    /// <param name="value">Valor a convertir. no se diferencia entre mayúsculas y minúsculas</param>
    /// <returns>Valor de la enumeración correspondiente</returns>
    /// <exception cref="ArgumentException">Si el valor a copnvertir no se encuentra en la enumeración</exception>
    /// <exception cref="ArgumentNullException">Si el valor a copnvertir es null</exception>
    public static TEnum ParseEnumValue<TEnum>(string value)
        where TEnum : struct, IConvertible
    {
        TEnum retorno = default;
        Type? tp = typeof(TEnum);
        if (!tp.IsEnum)
        {
            return retorno;
        }

        if (!typeof(TEnum).IsEnum)
        {
            return retorno;
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        // out _ (Se utiliza el discard de Csharp, porque no se necesita ese parametro)
        if (int.TryParse(value.Trim(), out _))
        {
            int paramValue = Convert.ToInt32(value);
            foreach (TEnum obj in Enum.GetValues(tp))
            {
                Enum? test = Enum.Parse(typeof(TEnum), obj.ToString()) as Enum;
                int x = Convert.ToInt32(test); // x is the integer value of enum
                if (x.Equals(paramValue))
                {
                    return obj;
                }
            }
            throw new ArgumentException(
                "El valor \"" + value + "\" no existe en la enumeración",
                nameof(value)
            );
        }
        else if (!Enum.TryParse(value, true, out retorno))
        {
            throw new ArgumentException(
                "El valor \"" + value + "\" no existe en la enumeración",
                nameof(value)
            );
        }
        return retorno;
    }
}
