using System.Security.Cryptography;
using System.Text;

namespace AdvancedEncryptionStandard.Archivos;

public class AesDecryptFile
{
    private readonly string _archivoAesTxt = "archivo.txt";
    private readonly string _archivoAesTxtCifrado = "archivo.txt.crypt";

    public void DescifrarAes()
    {
        try
        {
            Console.WriteLine("Escribe la contraseña");
            string? contrasenia = Console.ReadLine();

            using (HashAlgorithm hash = SHA256.Create())
            {
                using Aes? aesAlg = Aes.Create();
                aesAlg.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia!));

                // Create an encryptor to perform the stream transform.
                using ICryptoTransform? decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using FileStream? fileStreamCrypt = new(
                    _archivoAesTxtCifrado,
                    FileMode.Open,
                    FileAccess.Read
                );
                using FileStream? fileStreamOut = new(
                    _archivoAesTxt,
                    FileMode.OpenOrCreate,
                    FileAccess.Write
                );
                using CryptoStream? decryptStream = new(
                    fileStreamCrypt,
                    decryptor,
                    CryptoStreamMode.Read
                );
                for (int data; (data = decryptStream.ReadByte()) != -1; )
                {
                    fileStreamOut.WriteByte((byte)data);
                }
            }

            File.Delete(_archivoAesTxtCifrado);
            Console.WriteLine(File.ReadAllText(_archivoAesTxt));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}
