using Wiry.Base32;

namespace Totp.Libs;

/// <summary>
/// HMAC-based One-time Password
/// </summary>
public class Hotp : Otp
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="claveSecreta">Clave del hash</param>
    /// <param name="otpSize">Tamaño del código TOTP entre 1 y 9</param>
    private static void ValidaParametrosEntrada(byte[] claveSecreta, int otpSize)
    {
        if (!(claveSecreta != null))
        {
            throw new ArgumentNullException("claveSecreta");
        }

        if (!(claveSecreta.Length > 0))
        {
            throw new ArgumentException("claveSecreta empty");
        }

        if (!(otpSize >= OTP_MIN_SIZE))
        {
            throw new ArgumentOutOfRangeException("otpMinSize");
        }

        if (!(otpSize <= OTP_MAX_SIZE))
        {
            throw new ArgumentOutOfRangeException("otpMaxSize");
        }
    }

    /// <summary>
    /// Genera un código HOTP
    /// </summary>
    /// <param name="contador">Número con el que se calcula la OTP</param>
    /// <param name="claveSecreta">Clave compartida en Base32</param>
    /// <param name="hashMode">Tipo de Hash a aplicar</param>
    /// <param name="otpSize">Tamaño del código TOTP a generar</param>
    /// <returns>
    /// Código HOTP
    /// </returns>
    ///
    public static string GeneraHotp(
        long contador,
        string claveSecreta,
        int otpSize = 6,
        OtpHashMode hashMode = OtpHashMode.SHA1
    )
    {
        byte[]? key = Base32Encoding.Standard.ToBytes(claveSecreta);

        ValidaParametrosEntrada(key, otpSize);

        return Compute(key, contador, hashMode, otpSize);
    }

    /// <summary>
    /// Verifica un código hotp
    /// </summary>
    /// <param name="contador">Número con el que se calcula la OTP</param>
    /// <param name="hotp">Código a verificar</param>
    /// <param name="claveSecreta">Clave compartida en Base32</param>
    /// <param name="hashMode">Tipo de Hash a aplicar</param>
    /// <param name="otpSize">Tamaño del código TOTP a verificar</param>
    /// <returns>
    /// true/false
    /// </returns>
    public static bool ValidaHotp(
        long contador,
        string hotp,
        string claveSecreta,
        int otpSize = 6,
        OtpHashMode hashMode = OtpHashMode.SHA1
    )
    {
        byte[]? secretKey = Base32Encoding.Standard.ToBytes(claveSecreta);

        ValidaParametrosEntrada(secretKey, otpSize);

        return hotp == Compute(secretKey, contador, hashMode, otpSize);
    }
}
