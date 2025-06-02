using System.Security.Cryptography;

namespace Totp.Libs;

/// <summary>
/// One-time Password
/// </summary>
public abstract class Otp
{
    internal const int OTP_MIN_SIZE = 2;
    internal const int OTP_MAX_SIZE = 10;

    #region "Hmac"

    /// <summary>
    /// Create an HMAC object for the specified algorithm
    /// </summary>
    private static HMAC CreateHmacHash(OtpHashMode otpHashMode)
    {
        HMAC hmacAlgorithm = otpHashMode switch
        {
            OtpHashMode.SHA256 => new HMACSHA256(),
            OtpHashMode.SHA512 => new HMACSHA512(),
            OtpHashMode.SHA1 => new HMACSHA1(),
            _ => new HMACSHA1(),
        };

        return hmacAlgorithm;
    }

    /// <summary>
    /// Calcula el HMAC
    /// </summary>
    /// <param name="key">Clave del algoritmo</param>
    /// <param name="mode">Tipo de algoritmo HMAC</param>
    /// <param name="data">Dato para el cual se calcula el HMAC</param>
    /// <returns>HMAC calculado con la clave y el dato</returns>
    /// <returns></returns>
    private static byte[] ComputeHmac(byte[] key, OtpHashMode mode, byte[] data)
    {
        byte[] hashedValue = [];
        using HMAC? hmac = CreateHmacHash(mode);
        try
        {
            hmac.Key = key;
            hashedValue = hmac.ComputeHash(data);
        }
        catch
        {
            // ignored
        }

        return hashedValue;
    }

    #endregion

    /// <summary>
    /// Trunca un número al número de digitos especificado y
    /// devuelve la cadena que lo representa con ceros a la
    /// izquierda si fuera necesario.
    /// </summary>
    private static string Digits(long input, int numeroDigitos)
    {
        int truncatedValue = (int)input % (int)Math.Pow(10, numeroDigitos);
        return truncatedValue.ToString().PadLeft(numeroDigitos, '0');
    }

    /// <summary>
    /// converts a long into a big endian byte array.
    /// </summary>
    /// <remarks>
    /// RFC 4226 specifies big endian as the method for converting the counter to data to hash.
    /// </remarks>
    private static byte[] GetBigEndianBytes(long input)
    {
        // Since .net uses little endian numbers, we need to reverse the byte order to get big endian.
        byte[]? data = BitConverter.GetBytes(input);
        Array.Reverse(data);
        return data;
    }

    /// <summary>
    /// Helper method that calculates OTPs
    /// </summary>
    private static long CalculateOtp(byte[] claveSecreta, byte[] data, OtpHashMode mode)
    {
        byte[]? hmacComputedHash = ComputeHmac(claveSecreta, mode, data);

        // The RFC has a hard coded index 19 in this value.
        // This is the same thing but also accommodates SHA256 and SHA512
        // hmacComputedHash[19] => hmacComputedHash[hmacComputedHash.Length - 1]

        int offset = hmacComputedHash[^1] & 0x0F;
        return ((hmacComputedHash[offset] & 0x7f) << 24)
            | ((hmacComputedHash[offset + 1] & 0xff) << 16)
            | ((hmacComputedHash[offset + 2] & 0xff) << 8)
            | ((hmacComputedHash[offset + 3] & 0xff) % 1000000);
    }

    /// <summary>
    /// Cálcula un código OTP
    /// </summary>
    /// <param name="claveSecreta">Clave con la que se va a aplicar el hash</param>
    /// <param name="contador">El dato (número) al que se le va a aplicar el hash</param>
    /// <param name="mode">Tipo de Hash a aplicar</param>
    /// <param name="otpSize">Tamaño del código OTP entre 1 y 9</param>
    /// <returns>Código TOTP</returns>
    protected static string Compute(
        byte[] claveSecreta,
        long contador,
        OtpHashMode mode,
        int otpSize
    )
    {
        byte[]? data = GetBigEndianBytes(contador);
        long otp = CalculateOtp(claveSecreta, data, mode);
        return Digits(otp, otpSize);
    }
}
