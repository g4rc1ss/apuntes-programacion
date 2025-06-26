using Wiry.Base32;

namespace Totp.Libs;

/// <summary>
/// Time-based One-time Password
/// </summary>
public class Totp : Otp
{
    #region "Constantes"

    /// <summary>
    /// Número de ticks hasta la medianoche del 1-1-1970
    /// </summary>
    private const long UNIX_EPOCH_TICKS = 621355968000000000L;

    /// <summary>
    /// Divisor para convertir los ticks en segundos
    /// </summary>
    private const long TICKS_TO_SECONDS = 10000000L;

    #endregion

    #region "Private"

    /// <summary>
    ///
    /// </summary>
    /// <param name="claveSecreta">Clave del hash</param>
    /// <param name="tiempo">Numero de segundos de validez del código</param>
    /// <param name="otpSize">Tamaño del código TOTP entre 1 y 9</param>
    private static void ValidaParametrosEntrada(byte[] claveSecreta, int tiempo, int otpSize)
    {
        ArgumentNullException.ThrowIfNull(claveSecreta);
        if (!(claveSecreta.Length > 0))
        {
            throw new ArgumentException("claveSecreta empty");
        }

        if (!(tiempo > 0))
        {
            throw new ArgumentOutOfRangeException(nameof(tiempo));
        }

        if (!(otpSize >= OTP_MIN_SIZE))
        {
            throw new ArgumentOutOfRangeException(nameof(otpSize));
        }

        if (!(otpSize <= OTP_MAX_SIZE))
        {
            throw new ArgumentOutOfRangeException(nameof(otpSize));
        }
    }

    /// <summary>
    /// Calcula el número de intervalos de tiempoValidez segundos
    /// desde el 1/1/1970
    /// </summary>
    /// <param name="tiempoValidez">Periódo de validez del TOTP</param>
    /// <returns></returns>
    private static long CalculaIntervalo(int tiempoValidez)
    {
        long unixTimestamp = (DateTime.UtcNow.Ticks - UNIX_EPOCH_TICKS) / TICKS_TO_SECONDS;
        long window = unixTimestamp / tiempoValidez;
        return window;
    }

    #endregion

    #region "Métodos públicos"

    /// <summary>
    /// Calcula el número de segundos que quedan en el intervalo actual hasta el siguiente intervalo
    /// </summary>
    /// <param name="tiempo">Numero de segundos del intervalo de validez del código</param>
    /// <returns></returns>
    public static int RemainingSeconds(int tiempo = 30)
    {
        return tiempo
            - (int)((DateTime.UtcNow.Ticks - UNIX_EPOCH_TICKS) / TICKS_TO_SECONDS % tiempo);
    }

    /// <summary>
    /// Genera un código TOTP
    /// </summary>
    /// <param name="claveSecreta">Clave compartida en Base32</param>
    /// <param name="tiempo">Numero de segundos de validez del código</param>
    /// <param name="hashMode">Tipo de Hash a aplicar</param>
    /// <param name="otpSize">Tamaño del código TOTP a generar</param>
    /// <returns>
    /// Código TOTP
    /// </returns>
    public static string GeneraTotp(
        string claveSecreta,
        int tiempo = 30,
        int otpSize = 6,
        OtpHashMode hashMode = OtpHashMode.SHA1
    )
    {
        return GeneraTotp(Base32Encoding.Standard.ToBytes(claveSecreta), tiempo, otpSize, hashMode);
    }

    /// <summary>
    /// Genera un código TOTP
    /// </summary>
    /// <param name="claveSecreta">Clave secereta compartida</param>
    /// <param name="tiempo">Numero de segundos de validez del código</param>
    /// <param name="hashMode">Tipo de Hash a aplicar</param>
    /// <param name="otpSize">Tamaño del código TOTP a generar</param>
    /// <returns>
    /// Código TOTP
    /// </returns>
    private static string GeneraTotp(
        byte[] claveSecreta,
        int tiempo = 30,
        int otpSize = 6,
        OtpHashMode hashMode = OtpHashMode.SHA1
    )
    {
        ValidaParametrosEntrada(claveSecreta, tiempo, otpSize);

        long intervalo = CalculaIntervalo(tiempo);

        return Compute(claveSecreta, intervalo, hashMode, otpSize);
    }

    /// <summary>
    /// Verifica un código totp
    /// </summary>
    /// <param name="totp">Código a verificar</param>
    /// <param name="claveSecreta">Clave compartida en Base32</param>
    /// <param name="tiempo">Numero de segundos de validez del código</param>
    /// <param name="hashMode">Tipo de Hash a aplicar</param>
    /// <param name="otpSize">Tamaño del código TOTP a verificar</param>
    /// <returns>
    /// Válido = true/false
    /// Intervalo = nº de intervalo validado para guardarlo y que no se pueda volver a usar
    /// </returns>
    public static (bool Valido, long Intervalo) ValidaTotp(
        string totp,
        string claveSecreta,
        int tiempo = 30,
        int otpSize = 6,
        OtpHashMode hashMode = OtpHashMode.SHA1
    )
    {
        return ValidaTotp(
            totp,
            Base32Encoding.Standard.ToBytes(claveSecreta),
            tiempo,
            otpSize,
            hashMode
        );
    }

    /// <summary>
    /// Verifica un código totp
    /// </summary>
    /// <param name="totp">Código a verificar</param>
    /// <param name="claveSecreta">Clave secreta compartida</param>
    /// <param name="tiempo">Numero de segundos de validez del código</param>
    /// <param name="hashMode">Tipo de Hash a aplicar</param>
    /// <param name="otpSize">Tamaño del código TOTP a verificar</param>
    /// <returns>
    /// Válido = true/false
    /// Intervalo = nº de intervalo validado para guardarlo y que no se pueda volver a usar
    /// </returns>
    private static (bool Valido, long Intervalo) ValidaTotp(
        string totp,
        byte[] claveSecreta,
        int tiempo = 30,
        int otpSize = 6,
        OtpHashMode hashMode = OtpHashMode.SHA1
    )
    {
        ValidaParametrosEntrada(claveSecreta, tiempo, otpSize);

        long intervalo = CalculaIntervalo(tiempo);

        string? newTotp = Compute(claveSecreta, intervalo, hashMode, otpSize);
        if (newTotp == totp)
        {
            return (true, intervalo);
        }

        // Sí el intervalo actual no és válido, se valida el anterior para garantizar que hay
        // un margen tiempo definido para validar el código. Cuando se genera el TOTP siempre van a quedar menos tiempo
        // del definido para validarlo. Ejemplo con el tiempo definido por defecto de 30 segundos cuando se genera el código
        // hasta el siguiente intervalo pueden quedar de 1 a 30 segundos
        intervalo--;

        newTotp = Compute(claveSecreta, intervalo, hashMode, otpSize);
        return (newTotp == totp, intervalo);
    }

    /// <summary>
    /// Verifica un código totp
    /// </summary>
    /// <param name="totp">Código a verificar</param>
    /// <param name="claveSecreta">Clave secreta compartida</param>
    /// <param name="tiempo">Numero de segundos de validez del código</param>
    /// <param name="otpSize">Tamaño del código TOTP a verificar</param>
    /// <param name="hashMode">Tipo de Hash a aplicar</param>
    /// <returns>true/false </returns>
    public static bool ValidarTotp(
        string totp,
        string claveSecreta,
        int tiempo = 30,
        int otpSize = 6,
        OtpHashMode hashMode = OtpHashMode.SHA1
    )
    {
        (bool valido, _) = ValidaTotp(
            totp,
            Base32Encoding.Standard.ToBytes(claveSecreta),
            tiempo,
            otpSize,
            hashMode
        );

        return valido;
    }

    #endregion
}
