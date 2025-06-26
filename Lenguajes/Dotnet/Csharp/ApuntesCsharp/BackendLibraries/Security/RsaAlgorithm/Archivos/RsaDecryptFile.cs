using System.Security.Cryptography;
using System.Text;

namespace RsaAlgorithm.Archivos;

public class RsaDecryptFile
{
    private readonly string _archivoRsaTxt = "archivoRSA.txt";
    private readonly string _archivoRsaCrypt = "archivoRSA.crypt";

    public void DescifrarRsa()
    {
        try
        {
            // Instanciamos el algorimo asimétrico RSA
            using RSA? rsaCrypt = RSA.Create();
            // Establecemos la longitud de la clave que queremos usar
            rsaCrypt.KeySize = 4096;

            rsaCrypt.ImportRSAPublicKey(File.ReadAllBytes("public.key"), out int publicKey);
            rsaCrypt.ImportRSAPrivateKey(File.ReadAllBytes("private.key"), out int privateKey);

            // Desencriptamos el mensaje
            byte[]? mensajeDescifrado = rsaCrypt.Decrypt(
                File.ReadAllBytes(_archivoRsaCrypt),
                RSAEncryptionPadding.Pkcs1
            );
            string? mensajeOriginal = Encoding.Default.GetString(mensajeDescifrado);

            using (StreamWriter? archivoEscritura = File.CreateText(_archivoRsaTxt))
            {
                archivoEscritura.Write(mensajeOriginal);
            }

            // Sacamos el mensaje descifrado por consola
            Console.WriteLine("----------------------------------- \n Mensaje desencriptado:");
            Console.WriteLine(mensajeOriginal);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
