using System.Security.Cryptography;
using System.Text;

namespace AdvancedEncryptionStandard.Textos;

public class AesEncryptText
{
    private readonly string _archivoAesTxt = "archivo.txt";

    public void CifrarAes()
    {
        try
        {
            Console.WriteLine("Escribe el texto a encriptar");
            //Obtenemos un array de bytes del texto a cifrar
            string? textoCifrarBytes = Console.ReadLine();

            Console.WriteLine("Escribe la contraseña");
            string? contraseña = Console.ReadLine();

            byte[]? textoCifrado = null;
            using (HashAlgorithm hash = SHA256.Create())
            {
                using Aes? aesAlg = Aes.Create();
                aesAlg.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Create an encryptor to perform the stream transform.
                using ICryptoTransform? encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV); // Create the streams used for encryption.
                using MemoryStream? msEncrypt = new();
                using CryptoStream? csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter? swEncrypt = new(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(textoCifrarBytes);
                    textoCifrarBytes = string.Empty;
                }
                textoCifrado = msEncrypt.ToArray();
            }

            File.Delete(_archivoAesTxt);
            Console.WriteLine(Encoding.UTF8.GetString(textoCifrado));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
