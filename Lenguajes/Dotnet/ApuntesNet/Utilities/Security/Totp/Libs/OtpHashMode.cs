namespace Totp.Libs;

/// <summary>
/// Tipos de hash soportados
/// </summary>
public enum OtpHashMode
{
    /// <summary>
    /// Algoritmo Sha1
    /// </summary>
    SHA1 = 0,

    /// <summary>
    /// Algoritmo Sha256
    /// </summary>
    SHA256 = 1,

    /// <summary>
    /// Algoritmo Sha512
    /// </summary>
    SHA512 = 2,
}
