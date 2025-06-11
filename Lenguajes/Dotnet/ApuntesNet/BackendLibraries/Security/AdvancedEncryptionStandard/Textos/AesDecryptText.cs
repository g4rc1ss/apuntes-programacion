using System.Security.Cryptography;
using System.Text;

namespace AdvancedEncryptionStandard.Textos;

public class AesDecryptText
{
    private readonly string _archivoAES_TXT = "archivo.txt";

    public void DescifrarAES()
    {
        try
        {
            Console.WriteLine("Escribe el texto a descifrar");
            //Obtenemos un array de bytes del texto a cifrar
            byte[]? textoCifrado = Encoding.UTF8.GetBytes(Console.ReadLine());

            Console.WriteLine("Escribe la contraseña");
            string? contraseña = Console.ReadLine();

            string? textoDescifrado = null;
            using (HashAlgorithm hash = SHA256.Create())
            {
                using Aes? aesAlg = Aes.Create();
                aesAlg.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Create a decryptor to perform the stream transform.
                using ICryptoTransform? decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.
                using MemoryStream? msDecrypt = new(textoCifrado);
                using CryptoStream? csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader? srDecrypt = new(csDecrypt);
                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                textoDescifrado = srDecrypt.ReadToEnd();
            }

            File.Delete(_archivoAES_TXT);
            Console.WriteLine(textoDescifrado);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
